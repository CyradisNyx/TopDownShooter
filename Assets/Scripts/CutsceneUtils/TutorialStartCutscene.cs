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

        yield return TypeWriter("you're still alive...", 0);
        yield return TypeWriter("that power short seems like it took out most of the building", 0);
        yield return TypeWriter("we might be able to make a run for it", 0);
        yield return TypeWriter("...", 0);
        yield return TypeWriter("you don't have a weapon though", 0);
        yield return TypeWriter("i'll scout ahead, so be careful", 0);

        yield return Move(0, positions[0].transform.position, 5f);
        yield return Move(0, positions[1].transform.position, 5f);

        Destroy(actors[0]);

        yield return null;
    }
}
