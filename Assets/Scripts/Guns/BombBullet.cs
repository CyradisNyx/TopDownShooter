using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    float damage = 1f;
    float speed = 15f;
    float radius = 10f;

    public void Update()
    {
        Vector3 temp = transform.forward * Time.deltaTime * speed;
        temp.y = 0f;
        transform.position += temp;
    }

    void OnCollisionEnter(Collision coll)
    {
        //EventMaster.Instance.BulletImpact(damage, coll.gameObject);
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, radius);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            EventMaster.Instance.BulletImpact(damage, hitColliders[i].gameObject);
        }

        Destroy(gameObject);
    }
}
