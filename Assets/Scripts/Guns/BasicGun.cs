using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    public override string SpriteFile { get { return "Sprites/shittygun"; } }

    public override void OnClick(Vector3 mousePos)
    {
        //Shoot stuff
    }
}
