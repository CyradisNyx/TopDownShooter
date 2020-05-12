using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    Camera cam;
    GameObject player;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Player") { return; }

        cam.gameObject.GetComponent<FollowCam>().enabled = false;
    }
}
