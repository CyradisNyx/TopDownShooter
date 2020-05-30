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

        StartCoroutine(TextAppear("i am a cutscene", 0));

        yield return null;
    }
}
