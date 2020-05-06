using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : StateMachineBehaviour
{
    public float attackRange;
    public GameObject gunPoint;

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // check still in range
        RaycastHit hitInfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, attackRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                //hit player
                this.Shoot();
            }
            else
            {
                // hit something that's not the player
                animator.SetBool("inRange", false);
            }
        }
        else
        {
            // didnt hit anything
            animator.SetBool("inRange", false);
        }

    }

    public void Shoot()
    {

    }
}
