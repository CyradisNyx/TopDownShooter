﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    Sprite gunSprite;
    public virtual string SpriteFile { get; set; }
    public virtual float damage { get; set; }
    public virtual float range { get; set; }
    public virtual int bullets { get; set; }
    protected GameObject player;
    protected GameObject playerGun;

    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = true;
        canShoot = true;
        player = GameObject.Find("Player");
        playerGun = player.transform.GetChild(0).gameObject;
        gunSprite = Resources.Load<Sprite>(SpriteFile);
        GetComponent<Image>().sprite = gunSprite;
        Color temp = GetComponent<Image>().color;
        temp.a = 1;
        GetComponent<Image>().color = temp;

        EventMaster.Instance.onPause += Pause;

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
    public void Pause(bool isPaused) { this.canShoot = !isPaused; }

    void OnDisable()
    {
        gameObject.GetComponent<Image>().enabled = false;
        canShoot = false;
    }

    void OnEnable()
    {
        gameObject.GetComponent<Image>().enabled = true;
        canShoot = true;
    }
}
