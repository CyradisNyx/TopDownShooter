using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMidCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALMID"; } }
    public List<GameObject> positions;

    public override IEnumerator CutsceneProcedure()
    {
        Debug.Log("CutsceneMid");

        yield return TypeWriter("oh good, you made it!", 0);
        yield return TypeWriter("this is a gun", 0);
        yield return TypeWriter("run into it to pick it up", 0);
        yield return TypeWriter("then click left or right to assign it to the matching slot", 0);
        yield return TypeWriter("i'll scout ahead while you figure it out", 0);

        yield return Move(0, positions[0].transform.position, 5f);
        yield return Move(0, positions[1].transform.position, 5f);

        Destroy(actors[0]);

        yield return null;
    }
}
