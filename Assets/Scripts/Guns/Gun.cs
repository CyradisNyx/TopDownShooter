using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Sprite gunSprite;
    public virtual string SpriteFile { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        gunSprite = Resources.Load<Sprite>(SpriteFile);
        GetComponent<Image>().sprite = gunSprite;

        if (transform.parent.name == "LeftGun")
        {
            EventMaster.Instance.onLeftClick += OnClick;
        }
        else if (transform.parent.name == "RightGun")
        {
            EventMaster.Instance.onRightClick += OnClick;
        }
    }

    public virtual void OnClick(Vector3 mousePos) { }
}
