using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneStart : MonoBehaviour
{
    Camera cam;
    GameObject player;

    public enum Types
    {
        TUTORIALEND,
        TUTORIALMID,
        TUTORIALSTART,
    }

    public Types _type;

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
        player.GetComponent<MouseInput>().enabled = false;

        EventMaster.Instance.CutsceneStart(_type.ToString());
    }

    public void CutsceneEnd(string type)
    {
        if (type != _type.ToString()) { return; }

        cam.gameObject.GetComponent<FollowCam>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<MouseInput>().enabled = true;

        Destroy(this.gameObject);
    }
}
