using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public NavMeshAgent agent;
    public float rotationSpeed;
    public float viewDistance;

    protected bool toA; // if true; path to A, otherwise path to B

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.agent = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (similarVector3(animator.transform.position, pointA))
        {
            this.toA = false;
        }

        if (similarVector3(animator.transform.position, pointB))
        {
            this.toA = true;
        }

        RaycastHit hitInfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, viewDistance))
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.red);
                // Start aggroing, actively hunt player
            }
            else
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.white);
            }
        }
        else
        {
            Debug.DrawLine(animator.transform.position, animator.transform.position + animator.transform.forward * viewDistance, Color.green);
        }

        if (toA)
        {
            agent.SetDestination(pointA);
        }
        else
        {
            agent.SetDestination(pointB);
        }
    }

    protected bool similarVector3(Vector3 a, Vector3 b)
    {
        if (floatSimilar(a.x, b.x) == false) { return false; }
        if (floatSimilar(a.y, b.y) == false) { return false; }
        if (floatSimilar(a.z, b.z) == false) { return false; }

        return true;
    }

    bool floatSimilar(float float1, float float2)
    {
        float fudge = 0.01f; // 1 decimal place
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
