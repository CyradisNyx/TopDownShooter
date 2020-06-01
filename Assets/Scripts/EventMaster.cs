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

    public event Action<Vector3> onLeftClick;
    public void LeftClick(Vector3 mousePos)
    {
        if (onLeftClick != null)
        {
            onLeftClick(mousePos);
        }
    }

    public event Action<Vector3> onRightClick;
    public void RightClick(Vector3 mousePos)
    {
        if (onRightClick != null)
        {
            onRightClick(mousePos);
        }
    }

    public event Action<float, GameObject> onBulletImpact;
    public void BulletImpact(float damage, GameObject collision)
    {
        if (onBulletImpact != null)
        {
            onBulletImpact(damage, collision);
        }
    }

    public event Action<GameObject> onDeath;
    public void Death(GameObject victim)
    {
        if (onDeath != null)
        {
            onDeath(victim);
        }
    }

    public event Action<string, GameObject> onPickup;
    public void Pickup(string type, GameObject who)
    {
        if (onPickup != null)
        {
            onPickup(type, who);
        }
    }

    public event Action<string, string> onPickupGun;
    public void PickupGun(string type, string whichSlot)
    {
        if (onPickupGun != null)
        {
            onPickupGun(type, whichSlot);
        }
    }

    public event Action<string, string> onGunOut;
    public void GunOut(string type, string whichSlot)
    {
        if (onGunOut != null)
        {
            onGunOut(type, whichSlot);
        }
    }

    public event Action<string> onCutsceneStart;
    public void CutsceneStart(string type)
    {
        if (onCutsceneStart != null)
        {
            onCutsceneStart(type);
        }
    }

    public event Action<string> onCutsceneEnd;
    public void CutsceneEnd(string type)
    {
        if (onCutsceneEnd != null)
        {
            onCutsceneEnd(type);
        }
    }

    public event Action<bool> onPause;
    public void Pause(bool isPaused)
    {
        if (onPause != null)
        {
            onPause(isPaused);
        }
    }
}
