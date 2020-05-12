using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNext : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Player") { return; }

        Debug.Log("Load Next Scene");
    }
}
