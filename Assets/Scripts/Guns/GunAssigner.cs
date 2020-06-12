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
        count.ResetGun();
    }

    public void OnPickupGun(string type, string whichSlot)
    {
        if (transform.parent.name == "LeftGun" && whichSlot != "left") { return; }
        if (transform.parent.name == "RightGun" && whichSlot != "right") { return; }

        if (this.gameObject.GetComponent<Gun>() != null) { Destroy(this.gameObject.GetComponent<Gun>());}

        if (type == "BasicGun")
        {
            this.gameObject.AddComponent(typeof(BasicGun));
            count.gunComponent = this.gameObject.GetComponent<BasicGun>();
            count.ResetGun();
        }

        if (type == "BombGun")
        {
            this.gameObject.AddComponent(typeof(BombGun));
            count.gunComponent = this.gameObject.GetComponent<BombGun>();
            count.ResetGun();
        }

        if (type == "IceGun")
        {
            this.gameObject.AddComponent(typeof(IceGun));
            count.gunComponent = this.gameObject.GetComponent<IceGun>();
            count.ResetGun();
        }
    }
}
