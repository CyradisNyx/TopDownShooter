using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMidCutscene : Cutscene
{
    public override string CutsceneType { get { return "TUTORIALMID"; } }
    public List<GameObject> positions;

    public override IEnumerator CutsceneProcedure()
    {
        Debug.Log("CutsceneEnd");

        yield return TypeWriter("pickup a gun", 0);

        yield return Move(0, positions[0].transform.position);
        yield return Move(0, positions[1].transform.position);

        Destroy(actors[0]);

        yield return null;
    }
}
