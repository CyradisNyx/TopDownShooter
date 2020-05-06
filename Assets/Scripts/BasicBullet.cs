using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    float damage = 2f;
    float speed = 15f;

    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision coll)
    {
        EventMaster.Instance.BulletImpact(damage, coll.gameObject);
        Destroy(gameObject);
    }
}
