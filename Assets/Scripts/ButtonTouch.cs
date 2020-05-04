using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ouch");
        EventMaster.Instance.ButtonPress(collision.gameObject);
    }
}
