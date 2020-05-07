using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelfAwareness : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = coll.transform.position;
    }
}
