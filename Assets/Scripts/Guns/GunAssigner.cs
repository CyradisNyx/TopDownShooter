using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssigner : MonoBehaviour
{
    BulletCounter count;

    void Start()
    {
        EventMaster.Instance.onPickup += OnPickup;
        this.count = this.gameObject.transform.parent.Find("BulletCount").GetComponent<BulletCounter>();
    }

    public void OnPickup(string type)
    {
        if (type == "BasicGun")
        {
            this.gameObject.AddComponent(typeof(BasicGun));
            count.gunComponent = this.gameObject.GetComponent<BasicGun>();
            count.ResetGun();
        }
    }
}
