using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaster : MonoBehaviour
{
    public static EventMaster _instance;
    public static EventMaster Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public event Action<GameObject> onButtonPress;
    public void ButtonPress(GameObject collisionBoi)
    {
        if (onButtonPress != null)
        {
            onButtonPress(collisionBoi);
        }
    }
}
