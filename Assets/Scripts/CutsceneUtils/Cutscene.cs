using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    Camera cam;
    GameObject player;

    protected GameObject textBubble;
    protected Text textObject;

    public Transform scenePos;
    public List<GameObject> actors;
    public GameObject textBox;

    public virtual string CutsceneType { get; set; }
    public virtual float CutsceneLength { get; set; }

    bool active = false;
    protected bool continueText = false;

    Vector3 scenePosActual;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
        textBubble = Resources.Load<GameObject>("Prefabs/TextBubble");
        textObject = textBox.transform.GetChild(0).GetComponent<Text>();
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
        if (type != CutsceneType) { return; }

        this.active = true;
        textBox.SetActive(true);

        StartCoroutine(WaitSeconds(CutsceneLength));
        StartCoroutine(CutsceneProcedure());

        // Add text bubbles and play noise over actors
    }

    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        this.CloseScene();
    }

    public virtual IEnumerator CutsceneProcedure() { yield return null; }

    protected IEnumerator TypeWriter(string text)
    {
        this.textObject.text = text;
        yield return new WaitForSeconds(5f);
        this.continueText = true;

        yield return null;
    }

    void CloseScene()
    {
        this.active = false;
        textBox.SetActive(false);
        EventMaster.Instance.CutsceneEnd(CutsceneType);
    }
}
