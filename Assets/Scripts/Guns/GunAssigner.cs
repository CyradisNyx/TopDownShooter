using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssigner : MonoBehaviour
{
    BulletCounter count;

    void Start()
    {
        EventMaster.Instance.onPickupGun += OnPickupGun;
        this.count = this.gameObject.transform.parent.Find("BulletCount").GetComponent<BulletCounter>();
    }

    public void OnPickupGun(string type, string whichSlot)
    {
        if (transform.parent.name == "LeftGun" && whichSlot != "left") { return; }
        if (transform.parent.name == "RightGun" && whichSlot != "right") { return; }
        if (type == "BasicGun")
        {
            this.gameObject.AddComponent(typeof(BasicGun));
            count.gunComponent = this.gameObject.GetComponent<BasicGun>();
            count.ResetGun();
        }
    }
}
