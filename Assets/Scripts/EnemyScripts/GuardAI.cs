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

    State _state;
    NavMeshAgent agent;

    public Patrol patrol = new Patrol();
    public Shoot shoot = new Shoot();
    public Hunt hunt = new Hunt();
    public Scan scan = new Scan();

    public void Start()
    {
        this._state = State.StatePatrol;
        this.agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        // Check for being stuck, and reset to Patrol
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
                shoot.Update();
                break;
            case State.StateScan:
                scan.Update();
                break;
        }
    }

    [System.Serializable]
    public class Patrol
    {
        public Vector3 pointA;
        public Vector3 pointB;

        public float walkSpeed;
        public float viewDistance;

        public void Update()
        {

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
