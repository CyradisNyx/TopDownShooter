using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndCutscene : MonoBehaviour
{
    Camera cam;
    GameObject player;

    public Transform scenePos;
    public List<GameObject> actors;
    public GameObject textBox;

    bool active = false;
    Vector3 scenePosActual;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
        this.scenePosActual = scenePos.position;
        this.scenePosActual.y = cam.gameObject.transform.position.y;

        EventMaster.Instance.onCutsceneStart += CutsceneStart;
    }

    void Update()
    {
        if (!active) { return; }
        cam.gameObject.transform.position = Vector3.Lerp(cam.gameObject.transform.position, scenePosActual, Time.deltaTime);
    }

    public void CutsceneStart(string type)
    {
        if (type != "TUTORIALEND") { return; }

        this.active = true;
        textBox.SetActive(true);

        StartCoroutine(WaitSeconds(5f));

        // Add text bubbles and play noise over actors
    }

    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        this.CloseScene();

    }

    void CloseScene()
    {
        this.active = false;
        textBox.SetActive(false);
        EventMaster.Instance.CutsceneEnd("TUTORIAL");
    }
}
