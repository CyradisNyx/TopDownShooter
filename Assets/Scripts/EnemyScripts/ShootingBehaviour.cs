using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingBehaviour : StateMachineBehaviour
{
    public float attackRange;
    public GameObject gunPoint;
    public string BulletFile = "Prefabs/BulletPrefab";

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.gunPoint = animator.transform.GetChild(0).gameObject;
        animator.GetComponent<NavMeshAgent>().isStopped = true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<NavMeshAgent>().isStopped = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // check still in range
        RaycastHit hitInfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitInfo, attackRange))
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))
            {
                //hit player
                this.Shoot(hitInfo);
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

    public void Shoot(RaycastHit hitInfo)
    {
        Debug.DrawLine(gunPoint.transform.position, hitInfo.point, Color.white, 5);

        GameObject bullet = Resources.Load<GameObject>(BulletFile);
        GameObject currBullet = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
    }
}
