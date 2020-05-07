using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        EventMaster.Instance.onBulletImpact += BulletImpact;
    }

    public void BulletImpact(float damage, GameObject coll)
    {
        Debug.Log("EventCollider " + coll.name + ", Me " + this.gameObject.name);
        if (coll.name == this.gameObject.name)
        {
            health -= damage;
            if (floatSimilar(health, 0f))
            {
                EventMaster.Instance.Death(this.gameObject);
            }
        }
    }

    bool floatSimilar(float float1, float float2)
    {
        float fudge = 0.1f; // 1 decimal place
        return ((float1 + fudge) > float2) && ((float1 - fudge) < float2);
    }
}
