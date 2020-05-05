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
    protected bool rotatedCheck;
    protected Vector3 lastSeen;
    protected int spinCount = 0;

    // Equivalent of Start() in monobehaviour
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("hunting");
        this.agent = animator.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = walkSpeed;

        this.playerTarget = GameObject.Find("Player");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // This fucking idiot keeps getting stuck in corners, so this manually forces him into Patrol when that happens
        if (!agent.hasPath && agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            animator.SetBool("isHunting", false);
        }

        // Cast a ray forward to check in range for Player
        RaycastHit hitInfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, attackRangeEnd))
        {
            lastSeen = playerTarget.transform.position;

            // If hit player
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.red);
            }
            // If hit something else
            else
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.green);
            }
        }
        // All clear
        else
        {
            Debug.DrawLine(animator.transform.position, animator.transform.position + animator.transform.forward * attackRangeEnd, Color.green);
        }

        agent.destination = lastSeen;

        // if at last place
        if (similarVector3(animator.transform.position, lastSeen))
        {
            // go back to patrolling
            animator.SetBool("isHunting", false);
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
        float fudge = 0.1f; // 1 decimal place
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }
}
