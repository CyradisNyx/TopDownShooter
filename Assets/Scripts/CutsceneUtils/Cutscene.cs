using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    Camera cam;
    GameObject player;
    AudioSource textSound;

    protected GameObject textBubble;
    protected Text textObject;

    public Transform scenePos;
    public List<GameObject> actors;
    public GameObject textBox;

    public virtual string CutsceneType { get; set; }
    public virtual float CutsceneLength { get; set; }

    bool active = false;
    bool skipText = false;

    Vector3 scenePosActual;

    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
        textSound = textBox.GetComponent<AudioSource>();

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

        StartCoroutine(RunScene());
    }

    public virtual IEnumerator CutsceneProcedure() { yield return null; }

    protected IEnumerator TypeWriter(string text, int actorID = -1, float waitBetween = 0.1f)
    {
        if (actorID >= 0)
        {
            // Add text bubble, start talking noise
            Vector3 bubblePos = new Vector3(
                actors[actorID].transform.position.x + 0.5f,
                actors[actorID].transform.position.y + 2f,
                actors[actorID].transform.position.z + 1f
                );
            Vector3 bubbleRot = new Vector3(
                90f,
                0f,
                0f
                );

            GameObject textBubblePrefab = Instantiate(textBubble, bubblePos, Quaternion.Euler(bubbleRot));
            textBubblePrefab.transform.SetParent(actors[actorID].transform);
        }

        this.skipText = false;
        StartCoroutine(SkipText());

        for (int i = 0; i < text.Length; i++)
        {
            if (this.skipText) { i = text.Length - 1; }
            this.textObject.text = text.Substring(0, i + 1);
            textSound.pitch = Random.Range(0.9f, 1.1f);
            textSound.Play(0);
            float waitVariation = Random.Range(waitBetween - 0.05f, waitBetween + 0.05f);
            yield return new WaitForSeconds(waitVariation);
        }

        this.skipText = true;

        yield return new WaitUntil(() => Input.anyKeyDown);

        if (actorID >= 0)
        {
            // Remove text bubble, end talking noise
            Destroy(actors[actorID].transform.GetChild(0).gameObject);
        }
        yield return null;
    }

    protected IEnumerator SkipText()
    {
        while (this.skipText == false)
        {
            if (Input.anyKeyDown && !Input.GetKeyDown("escape"))
            {
                this.skipText = true;
            }
            yield return null;
        }

        yield return null;
    }

    protected IEnumerator Kill(int actorID)
    {
        EventMaster.Instance.Death(actors[actorID]);
        yield return null;
    }

    protected IEnumerator Move(int actorID, Vector3 moveTo, float speed = 7f)
    {
        while (Vector3.Distance(actors[actorID].transform.position, moveTo) >= 0.5f)
        {
            Debug.Log("moving");
            actors[actorID].transform.position = Vector3.MoveTowards(actors[actorID].transform.position, moveTo, speed * Time.deltaTime);
            yield return null;
        }

        yield return null;
    }

    IEnumerator RunScene()
    {
        yield return CutsceneProcedure();

        this.active = false;
        textBox.SetActive(false);
        EventMaster.Instance.CutsceneEnd(CutsceneType);

        yield return null;
    }
}
