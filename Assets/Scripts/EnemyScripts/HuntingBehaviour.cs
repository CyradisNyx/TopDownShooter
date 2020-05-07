using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehaviour : StateMachineBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject playerTarget;
    public float walkSpeed;
    public float attackRange;
    public float viewRange;

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

        bool canSee = canSeePlayer(animator);
        agent.destination = lastSeen;

        if (!canSee)
        {
            // if at last place
            if (similarVector3(animator.transform.position, lastSeen))
            {
                // make him turn and check for the player here

                // go back to patrolling
                animator.SetBool("isHunting", false);
            }
        }
    }

    protected bool canSeePlayer(Animator animator)
    {
        // Return if can see player, else false
        RaycastHit hitInfo;

        // Cast Ray. Current location, forwards direction, hitInfo output, viewing distance
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, viewRange))
        {
            this.lastSeen = hitInfo.point;

            // If hit player
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.red);

                // Check against attack range
                if (hitInfo.distance <= attackRange)
                {
                    Debug.Log("in range");
                    animator.SetBool("inRange", true);
                }

                return true;
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
            Debug.DrawLine(animator.transform.position, animator.transform.position + animator.transform.forward * viewRange, Color.green);
        }

        return false;
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
