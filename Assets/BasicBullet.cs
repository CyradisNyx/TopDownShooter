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

    void OnTriggerEnter(Collider coll)
    {
        EventMaster.Instance.BulletImpact(coll.gameObject);
        Destroy(gameObject);
    }
}
