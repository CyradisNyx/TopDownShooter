using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLevel : MonoBehaviour
{
    public TextAsset file;
    public GameObject tilePrefab;

    private int levelX;
    private int levelZ;
    private GameObject[,] tiles;

    void Start()
    {
        string[] asString = GenerateLevel();
        tiles = GenerateTiles(asString);
    }

    private string[] GenerateLevel()
    {
        string[] fileContents = file.text.Split('\n');
        for (int i = 0; i < fileContents.Length; i++)
        {
            fileContents[i] = fileContents[i].Remove(fileContents[i].Length - 1);
        }

        levelX = fileContents[0].Length;
        levelZ = fileContents.Length;

        Debug.Log("Level is : (" + levelX + ", " + levelZ + ")");

        return fileContents;
    }

    private GameObject[,] GenerateTiles(string[] strings)
    {
        GameObject[,] myTiles = new GameObject[levelX, levelZ];

        for (int x = 0; x < levelX; x++)
        {
            for (int z = 0; z < levelZ; z++)
            {
                myTiles[x, z] = TileMaker(strings[x][z], new Vector3(x, 0, z));
            }
        }     

        return myTiles;
    }

    private GameObject TileMaker(char type, Vector3 pos)
    {
        GameObject output = Instantiate(tilePrefab, pos, Quaternion.identity);
        output.transform.SetParent(gameObject.transform);

        if (type == ' ')
        {
            Tile tileComp = output.AddComponent(typeof(TileNone)) as TileNone;
        }
        else if (type == '1')
        {
            Tile tileComp = output.AddComponent(typeof(TileWall)) as TileWall;
        }
        else if (type == '0')
        {
            Tile tileComp = output.AddComponent(typeof(TileFloor)) as TileFloor;
        }

        return output;
    }
}
