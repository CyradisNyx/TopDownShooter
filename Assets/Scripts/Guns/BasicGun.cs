using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    public override string SpriteFile { get { return "Sprites/shittygun"; } }
    public override float damage { get { return 2f; } }
    public override float range { get { return 12f; } }

    public override void OnClick(Vector3 mousePos)
    {
        Vector3 direction = (mousePos - player.transform.position).normalized;

        RaycastHit hitInfo;
        if (Physics.Raycast(player.transform.position, direction, out hitInfo, range))
        {
            Debug.DrawLine(player.transform.position, hitInfo.point, Color.white, 5);

        }
    }
}
