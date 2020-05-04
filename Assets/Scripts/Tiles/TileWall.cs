using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWall : Tile
{
    public override string MaterialFile { get { return "Materials/Wall"; } }
    string wallFile = "Prefabs/WallPrefab";
    GameObject wallPrefab;
    GameObject wallObject;

    protected override void Constructor()
    {
        base.Constructor();
        wallPrefab = Resources.Load<GameObject>(wallFile);
        wallPrefab = Instantiate(wallPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
