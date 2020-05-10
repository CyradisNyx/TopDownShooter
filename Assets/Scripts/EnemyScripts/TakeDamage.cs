using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float fullHealth;

    float health;

    // Start is called before the first frame update
    void Start()
    {
        EventMaster.Instance.onBulletImpact += BulletImpact;
        EventMaster.Instance.onPickup += Pickup;

        this.health = fullHealth;
    }

    public float getHealth() { return health; }

    public void BulletImpact(float damage, GameObject coll)
    {
        //Debug.Log("EventCollider " + coll.name + ", Me " + this.gameObject.name);
        if (coll.name == this.gameObject.name)
        {
            health -= damage;

            if (floatSimilar(health, 0f) || health < 0f)
            {
                EventMaster.Instance.Death(this.gameObject);
            }
        }
    }

    public void Pickup(string type, GameObject who)
    {
        if (type == "Health" && who.name == this.gameObject.name)
        {
            health = fullHealth;
        }
    }

    void OnDestroy()
    {
        EventMaster.Instance.onBulletImpact -= BulletImpact;
    }

    bool floatSimilar(float float1, float float2)
    {
        float fudge = 0.1f; // 1 decimal place
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }
}
