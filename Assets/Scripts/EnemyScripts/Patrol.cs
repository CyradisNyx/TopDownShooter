using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public UnityEngine.AI.NavMeshAgent agent;
    public float rotationSpeed;
    public float viewDistance;

    protected bool toA; // if true; path to A, otherwise path to B

    void Update()
    {
        if (similarVector3(transform.position, pointA))
        {
            this.toA = false;
        }

        if (similarVector3(transform.position, pointB))
        {
            this.toA = true;
        }

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, viewDistance))
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            } else
            {
                Debug.DrawLine(transform.position, hitInfo.point, Color.white);
            }
        } else {
            Debug.DrawLine(transform.position, transform.position + transform.forward * viewDistance, Color.green);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (toA)
        {
            agent.SetDestination(pointA);
        } else
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
}
