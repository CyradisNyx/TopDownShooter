using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    int bulletsLeft;
    public Text bulletCount;
    public Gun gunComponent;
    string type;
    string whichSlot;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent.name == "LeftGun")
        {
            EventMaster.Instance.onLeftClick += OnClick;
            whichSlot = "left";
        }
        else if (transform.parent.name == "RightGun")
        {
            EventMaster.Instance.onRightClick += OnClick;
            whichSlot = "right";
        }

        this.bulletCount = gameObject.GetComponent<Text>();
        if (this.transform.parent.GetChild(0).GetComponent<Gun>() != null) { ResetGun(); }
    }

    void Update()
    {
        bulletCount.text = bulletsLeft.ToString();
    }

    public void OnClick(Vector3 mousePos)
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft -= 1;
            if (bulletsLeft == 0)
            {
                //gunComponent.canShoot = false;
                EventMaster.Instance.GunOut(type, whichSlot);
                Destroy(gunComponent);
            }
        }
    }

    public void ResetGun()
    {
        if (this.transform.parent.GetChild(0).GetComponent<Gun>() == null) { return;}
        this.bulletsLeft = transform.parent.GetChild(0).GetComponent<Gun>().bullets;
        this.gunComponent = transform.parent.GetChild(0).GetComponent<Gun>();

        type = transform.parent.GetChild(0).GetComponent<Gun>().GetType().ToString();
    }
}
