using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{

    protected Material material;
    public virtual string MaterialFile { get; set; }

    public void Start()
    {
        if (MaterialFile == null)
        {
            //throw new Exception("TileMaterial not found");
        }

        material = Resources.Load<Material>(MaterialFile);
        GetComponent<Renderer>().material = material;
    }

    public void setArrayCoords(int[] arrayPos)
    {
        return;
    }
}
