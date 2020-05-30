using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEndCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALEND"; } }
    public override float CutsceneLength { get { return 20f; } }
    bool continueText = false;

    public override IEnumerator CutsceneProcedure()
    {
        this.continueText = false;
        Debug.Log("CutsceneEnd");

        StartCoroutine(TypeWriter("I AM A CUTSCENE"));
        yield return new WaitUntil(() => this.continueText == true);
        this.continueText = false;

        yield return null;
    }

    IEnumerator TypeWriter(string text)
    {
        this.textObject.text = text;
        yield return new WaitForSeconds(5f);
        this.continueText = true;

        yield return null;
    }
}
