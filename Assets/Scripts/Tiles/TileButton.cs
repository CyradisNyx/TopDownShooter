using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileButton : TileFloor
{
    string buttonFile = "Prefabs/ButtonPrefab";
    GameObject buttonPrefab;

    protected override void Constructor()
    {
        buttonPrefab = Resources.Load<GameObject>(buttonFile);
        buttonPrefab = Instantiate(buttonPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
