using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBurst : MonoBehaviour
{
    string particlePath = "Prefabs/DeathBurst";
    ParticleSystem deathParticles;

    void Start()
    {
        EventMaster.Instance.onDeath += Death;
        deathParticles = Resources.Load<ParticleSystem>(particlePath);
    }

    public void Death(GameObject victim)
    {
        if (victim != this.gameObject) { return; }

        Instantiate(deathParticles, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(this.gameObject);
    }
}
