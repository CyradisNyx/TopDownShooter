using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDoor : Tile
{
    public override string MaterialFile { get { return "Materials/Door"; } }
    string doorFile = "Prefabs/DoorPrefab";
    GameObject doorPrefab;

    protected override void Constructor()
    {
        base.Constructor();
        doorPrefab = Resources.Load<GameObject>(doorFile);
        doorPrefab = Instantiate(doorPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
