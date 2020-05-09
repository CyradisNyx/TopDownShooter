using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicGun : Gun
{
    public override string SpriteFile { get { return "Sprites/Guns/StupidBasic"; } }
    string BulletFile = "Prefabs/BulletPrefab";
    public override float range { get { return 20f; } }
    public override int bullets { get { return 20; } }

    public override void OnClick(Vector3 mousePos)
    {
        if (!canShoot) { return; }
        Vector3 direction = (mousePos - player.transform.position).normalized;

        RaycastHit hitInfo;
        if (Physics.Raycast(playerGun.transform.position, direction, out hitInfo, range))
        {
            Debug.DrawLine(playerGun.transform.position, hitInfo.point, Color.white, 5);

        }

        GameObject bullet = Resources.Load<GameObject>(BulletFile);
        GameObject currBullet = Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation);
    }

    void OnDisable()
    {
        gameObject.GetComponent<Image>().enabled = false;
        canShoot = false;
    }
}