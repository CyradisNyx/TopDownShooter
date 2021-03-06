﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEndCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALEND"; } }
    public List<GameObject> positions;

    public override IEnumerator CutsceneProcedure()
    {
        Debug.Log("CutsceneEnd");

        yield return TypeWriter("i told you this would happen", 0);
        yield return TypeWriter("we will squash the resistance!", 0);

        yield return TypeWriter("please...", 1, 0.3f);
        yield return TypeWriter("no...", 1, 0.5f);
        StartCoroutine(Kill(1));

        yield return TypeWriter("*he kills your guide friend*");

        yield return TypeWriter("mwahahahahahaha", 0);
        yield return TypeWriter("now no one can stop me!", 0);

        yield return Move(0, positions[0].transform.position);

        yield return null;
    }
}
