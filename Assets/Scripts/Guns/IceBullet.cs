using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    float damage = 2f;
    float speed = 15f;

    public void Update()
    {
        Vector3 temp = transform.forward * Time.deltaTime * speed;
        temp.y = 0f;
        transform.position += temp;
    }

    void OnCollisionEnter(Collision coll)
    {
        EventMaster.Instance.BulletImpact(damage, coll.gameObject);
        EventMaster.Instance.Slow(coll.gameObject);
        Destroy(gameObject);
    }
}
