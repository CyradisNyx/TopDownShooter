using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    void Start()
    {
        EventMaster.Instance.onButtonPress += this.OnButtonPress;
    }

    public void OnButtonPress(GameObject collider)
    {
        Debug.Log("door hear");
    }
}
