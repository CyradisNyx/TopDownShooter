using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssigner : MonoBehaviour
{
    void Start()
    {
        EventMaster.Instance.onPickup += OnPickup;
    }

    public void OnPickup(string type)
    {
        if (type == "BasicGun")
        {
            this.gameObject.AddComponent(typeof(BasicGun));
        }
    }
}
