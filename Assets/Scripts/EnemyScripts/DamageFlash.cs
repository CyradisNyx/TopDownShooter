using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    Color originalColour;
    Color flashColour;

    bool locked;

    float secondsGoal = 0.1f;
    float secondsElapsed;

    void Start()
    {
        EventMaster.Instance.onBulletImpact += BulletImpact;

        originalColour = this.gameObject.GetComponent<MeshRenderer>().material.color;
        flashColour = originalColour * 0.5f;
    }

    void Update()
    {
        if (locked)
        {
            secondsElapsed += Time.deltaTime;
            if (secondsElapsed >= secondsGoal)
            {
                locked = false;
                this.gameObject.GetComponent<MeshRenderer>().material.color = originalColour;
            }
        }
    }

    void OnDestroy()
    {
        EventMaster.Instance.onBulletImpact -= BulletImpact;
    }

    void BulletImpact(float damage, GameObject coll)
    {
        if (coll.name != this.gameObject.name) { return; }
        this.locked = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = flashColour;
    }
}
