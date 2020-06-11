using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public enum State
    {
        StatePatrol,
        StateShoot,
        StateHunt,
        StateScan,
    }

    public State _state;
    NavMeshAgent agent;

    public Patrol patrol;
    public Shoot shoot;
    public Hunt hunt;
    public Scan scan;

    public Vector3 patrolPointA;
    public Vector3 patrolPointB;

    public bool paused;
    public bool moving;

    public void Start()
    {
        this._state = State.StatePatrol;
        this.agent = gameObject.GetComponent<NavMeshAgent>();

        this.patrol = new Patrol(this.gameObject);
        this.hunt = new Hunt(this.gameObject);
        this.shoot = new Shoot(this.gameObject);
        this.scan = new Scan(this.gameObject);

        EventMaster.Instance.onBulletImpact += BulletImpact;
        EventMaster.Instance.onCutsceneStart += CutsceneStart;
        EventMaster.Instance.onCutsceneEnd += CutsceneEnd;
    }

    public void Update()
    {
        this.gameObject.transform.Find("Sprite").GetComponent<Animator>().SetBool("Moving", moving);

        // Check for being stuck, and reset to Patrol
        if (paused) { return; }
        if (!agent.hasPath && agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            this._state = State.StatePatrol;
        }

        switch (_state)
        {
            case State.StatePatrol:
                patrol.Update();
                break;
            case State.StateShoot:
                shoot.Update();
                break;
            case State.StateHunt:
                hunt.Update();
                break;
            case State.StateScan:
                scan.Update();
                break;
        }
    }

    public void OnDestroy() { EventMaster.Instance.onBulletImpact -= BulletImpact; }

    public void OnCollisionEnter(Collision coll) { this._state = State.StateScan; }

    public void BulletImpact(float damage, GameObject coll) { if (coll.name == this.gameObject.name) { this._state = State.StateScan; } }

    public void CutsceneStart(string type) { paused = true; }

    public void CutsceneEnd(string type) { paused = false; }

    bool SimilarVector3(Vector3 a, Vector3 b)
    {
        if (FloatSimilar(a.x, b.x) == false) { return false; }
        if (FloatSimilar(a.y, b.y) == false) { return false; }
        if (FloatSimilar(a.z, b.z) == false) { return false; }

        return true;
    }

    bool FloatSimilar(float float1, float float2)
    {
        float fudge = 0.1f;
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }

    bool SeePlayer(float range)
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
        {
            // If hit player
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                return true;
            }
            // If hit something else
            else { Debug.DrawLine(transform.position, hitInfo.point, Color.green); }
        }
        // All clear
        else { Debug.DrawLine(transform.position, transform.position + transform.forward * range, Color.green); }
        return false;
    }

    public class Patrol
    {
        public Vector3 pointA = new Vector3 ( 10, 1, 5 );
        public Vector3 pointB = new Vector3 ( 10, 1, 30 );

        public float walkSpeed = 3f;
        public float viewDistance = 10f;

        private bool toA = false;
        private GameObject parent;
        private GuardAI sm;

        public Patrol(GameObject parent)
        {
            this.parent = parent;
            this.sm = parent.GetComponent<GuardAI>();
            pointA = sm.patrolPointA;
            pointB = sm.patrolPointB;
        }

        public void Update()
        {
            sm.moving = true;

            // If at pointA/B, reverse direction to the other
            if (sm.SimilarVector3(sm.transform.position, pointA)) { this.toA = false; }
            if (sm.SimilarVector3(sm.transform.position, pointB)) { this.toA = true; }

            // If guard can see player, change to StateHunt
            if (sm.SeePlayer(viewDistance)) { sm._state = GuardAI.State.StateHunt; }

            // Move to pointA if toA else pointB
            sm.agent.SetDestination(toA ? pointA : pointB);
        }
    }

    public class Hunt
    {
        public float walkSpeed = 5f;
        public float viewDistance = 15f;
        public float attackDistance = 10f;

        public Vector3 lastSeen;
        private GameObject parent;
        private GuardAI sm;

        public Hunt(GameObject parent)
        {
            this.parent = parent;
            this.sm = parent.GetComponent<GuardAI>();
        }

        public void Update()
        {
            sm.moving = true;

            // If guard can see player, save their location
            if (sm.SeePlayer(viewDistance))
            {
                this.lastSeen = GameObject.Find("Player").transform.position;

                if (sm.SeePlayer(attackDistance)) { sm._state = GuardAI.State.StateShoot; }
                else { sm.agent.SetDestination(lastSeen); }
            }
            else
            {
                if (sm.SimilarVector3(sm.transform.position, lastSeen)) { sm._state = GuardAI.State.StateScan; }
                else { sm.agent.SetDestination(lastSeen); }
            }
        }
    }

    public class Shoot
    {
        public float attackDistance = 10f;
        public string bulletPrefab = "Prefabs/BulletPrefab";
        public int framesBetween = 50;

        private GameObject parent;
        private GameObject gunPoint;
        private GuardAI sm;
        private bool locked;
        private int waitCount;

        public Shoot(GameObject parent)
        {
            this.parent = parent;
            this.gunPoint = parent.transform.GetChild(0).gameObject;
            this.sm = parent.GetComponent<GuardAI>();
            waitCount = framesBetween;
        }

        public void Update()
        {
            sm.moving = false;
            sm.agent.isStopped = true;

            if (waitCount < framesBetween)
            {
                waitCount++; sm.agent.isStopped = false;
                return;
            }

            if (sm.SeePlayer(attackDistance))
            {
                GameObject bullet = Resources.Load<GameObject>(bulletPrefab);
                Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
                waitCount = 0;             
            }
            else { sm._state = GuardAI.State.StateHunt; }

            sm.agent.isStopped = false;
        }
    }

    public class Scan
    {
        public float turnDegrees = 10f;
        public float attackDistance = 10f;
        public float numRays;

        private GameObject parent;
        private GuardAI sm;

        public Scan(GameObject parent)
        {
            this.parent = parent;
            this.sm = parent.GetComponent<GuardAI>();
            this.numRays = 360f / turnDegrees;
        }

        public void Update()
        {
            sm.moving = false;
            sm.agent.isStopped = true;

            // Spin around and check each ray
            if (DoScan()) { sm._state = GuardAI.State.StateHunt; }
            else { sm._state = GuardAI.State.StatePatrol; }

            sm.agent.isStopped = false;
        }

        public bool DoScan()
        {
            // return true if find player in radius, else false
            // move player while scanning, so that if true, will be facing player when back to hunt
            // maybe also force set Hunt's lastSeen
            for (int i = 0; i < numRays; i++)
            {
                if (sm.SeePlayer(attackDistance))
                {
                    sm.hunt.lastSeen = GameObject.Find("Player").transform.position;
                    return true;
                }
                parent.transform.Rotate(0, turnDegrees, 0);
            }

            return false;
        }
    }
}
