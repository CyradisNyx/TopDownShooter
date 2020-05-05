﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    public override string SpriteFile { get { return "Sprites/shittygun"; } }
    string BulletFile = "Prefabs/BulletPrefab";
    public override float range { get { return 5f; } }

    public override void OnClick(Vector3 mousePos)
    {
        Vector3 direction = (mousePos - player.transform.position).normalized;

        RaycastHit hitInfo;
        if (Physics.Raycast(playerGun.transform.position, direction, out hitInfo, range))
        {
            Debug.DrawLine(playerGun.transform.position, hitInfo.point, Color.white, 5);

        }

        GameObject bullet = Resources.Load<GameObject>(BulletFile);
        GameObject currBullet = Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation);
    }
}
