using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;
    public float xOffset;
    public float yOffset;
    public float zOffset;

    private Vector3 velocity = Vector3.zero;
    private float smoothing = 0.3f;

    void FixedUpdate()
    {
        Vector3 targetPos = target.transform.position;
        targetPos.x += xOffset;
        targetPos.y += yOffset;
        targetPos.z += zOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothing);
    }
}
