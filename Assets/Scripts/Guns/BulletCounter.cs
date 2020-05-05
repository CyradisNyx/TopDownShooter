using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name == "LeftGun")
        {
            EventMaster.Instance.onLeftClick += OnClick;
        }
        else if (transform.parent.name == "RightGun")
        {
            EventMaster.Instance.onRightClick += OnClick;
        }
    }

    public void OnClick(Vector3 mousePos)
    {
        Debug.Log("click");
    }
}
