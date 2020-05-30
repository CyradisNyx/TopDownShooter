using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEndCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALEND"; } }
    public override float CutsceneLength { get { return 20f; } }

    public override IEnumerator CutsceneProcedure()
    {
        Debug.Log("CutsceneEnd");

        StartCoroutine(TypeWriter("i am a cutscene"));
        yield return new WaitUntil(() => this.continueText == true);
        this.continueText = false;

        StartCoroutine(TypeWriter("ooooooooo"));
        yield return new WaitUntil(() => this.continueText == true);
        this.continueText = false;

        yield return null;
    }
}
