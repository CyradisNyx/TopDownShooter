using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStartCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALSTART"; } }
    public List<GameObject> positions;

    public override IEnumerator CutsceneProcedure()
    {
        Debug.Log("CutsceneStart");

        yield return TypeWriter("you're still alive. good...", 0);

        yield return Move(0, positions[0].transform.position, 5f);
        yield return Move(0, positions[1].transform.position, 5f);

        Destroy(actors[0]);

        yield return null;
    }
}
