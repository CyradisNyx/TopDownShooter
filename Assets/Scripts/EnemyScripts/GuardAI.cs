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
    public Shoot shoot = new Shoot();
    public Hunt hunt = new Hunt();
    public Scan scan = new Scan();

    public void Start()
    {
        this._state = State.StatePatrol;
        this.agent = gameObject.GetComponent<NavMeshAgent>();

        this.patrol = new Patrol(this.gameObject);
    }

    public void Update()
    {
        // Check for being stuck, and reset to Patrol
        /**
        if (!agent.hasPath && agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            this._state = State.StatePatrol;
        }
    **/

        switch (_state)
        {
            case State.StatePatrol:
                patrol.Update();
                break;
            case State.StateShoot:
                shoot.Update();
                break;
            case State.StateHunt:
                shoot.Update();
                break;
            case State.StateScan:
                scan.Update();
                break;
        }
    }

    bool similarVector3(Vector3 a, Vector3 b)
    {
        if (floatSimilar(a.x, b.x) == false) { return false; }
        if (floatSimilar(a.y, b.y) == false) { return false; }
        if (floatSimilar(a.z, b.z) == false) { return false; }

        return true;
    }

    bool floatSimilar(float float1, float float2)
    {
        float fudge = 0.1f;
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }

    bool seePlayer(float range)
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

    [System.Serializable]
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
        }

        public void Update()
        {
            // If at pointA/B, reverse direction to the other
            if (sm.similarVector3(sm.transform.position, pointA)) { this.toA = false; }
            if (sm.similarVector3(sm.transform.position, pointB)) { this.toA = true; }

            // If guard can see player, change to StateHunt
            if (sm.seePlayer(viewDistance)) { sm._state = GuardAI.State.StateHunt; }

            // Move to pointA if toA else pointB
            sm.agent.SetDestination(toA ? pointA : pointB);
        }
    }

    [System.Serializable]
    public class Hunt
    {
        public void Update()
        {

        }
    }

    [System.Serializable]
    public class Shoot
    {
        public void Update()
        {

        }
    }

    [System.Serializable]
    public class Scan
    {
        public void Update()
        {

        }
    }
}
