﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBurst : MonoBehaviour
{
    public GameObject deathParticles;

    void Start()
    {
        EventMaster.Instance.onDeath += Death;
    }

    public void Death(GameObject victim)
    {
        if (victim != this.gameObject) { return; }

        Instantiate(deathParticles, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(this.gameObject);
    }

    public void OnDestroy()
    {
        EventMaster.Instance.onDeath -= Death;
    }
}
