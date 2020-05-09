using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour
{
    int bulletsLeft;
    public Text bulletCount;
    public Gun gunComponent;

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
        if (this.gameObject.GetComponent<Gun>() != null) { ResetGun(); }
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
                Destroy(gunComponent);
            }
        }
    }

    public void ResetGun()
    {
        this.bulletsLeft = transform.parent.GetChild(0).GetComponent<Gun>().bullets;
        this.gunComponent = transform.parent.GetChild(0).GetComponent<Gun>();
    }
}
