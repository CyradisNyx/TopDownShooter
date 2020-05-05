using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehaviour : StateMachineBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject playerTarget;
    public float walkSpeed;
    public float attackRangeStart;
    public float attackRangeEnd;

    protected bool lockOn;
    protected Vector3 lastSeen;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.agent = animator.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = walkSpeed;

        this.playerTarget = GameObject.Find("Player");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, attackRangeEnd))
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                lockOn = true;
                lastSeen = playerTarget.transform.position;
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.red);
            }
            else
            {
                lockOn = false;
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.white);
            }
        }
        else
        {
            Debug.DrawLine(animator.transform.position, animator.transform.position + animator.transform.forward * attackRangeEnd, Color.green);
        }

        if (lockOn) { agent.destination = playerTarget.transform.position; }
        else
        {
            Debug.Log("going to last known position");
            agent.destination = lastSeen;
        }

    }
}
