using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCutscene : MonoBehaviour
{
    Camera cam;
    GameObject player;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
        EventMaster.Instance.onCutsceneEnd += CutsceneEnd;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag != "Player") { return; }

        cam.gameObject.GetComponent<FollowCam>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        EventMaster.Instance.CutsceneStart("Tutorial");
    }

    public void CutsceneEnd(string type)
    {
        if (type != "Tutorial") { return; }
        cam.gameObject.GetComponent<FollowCam>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
