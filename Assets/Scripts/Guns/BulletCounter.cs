using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    int bulletsLeft;
    public Text bulletCount;

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

        this.bulletCount = gameObject.GetComponent<Text>();
        this.bulletsLeft = transform.parent.GetChild(0).GetComponent<Gun>().bullets;
    }

    void Update()
    {
        bulletCount.text = bulletsLeft.ToString();
    }

    public void OnClick(Vector3 mousePos)
    {
        Debug.Log("click");
        bulletsLeft -= 1;
    }
}
