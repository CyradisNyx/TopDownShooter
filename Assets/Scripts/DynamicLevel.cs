using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLevel : MonoBehaviour
{
    public TextAsset file;

    private int levelX;
    private int levelY;
    private GameObject[,] tiles;


    private enum TileTypes
    {
        None, // Space
        Floor, // 0
        Wall, // 1
    }

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
        levelY = fileContents.Length;

        Debug.Log("Level is : (" + levelX + ", " + levelY + ")");

        return fileContents;
    }

    private GameObject[,] GenerateTiles(string[] strings)
    {
        GameObject[,] myTiles = new GameObject[levelX, levelY];
        

        return myTiles;
    }
}
