using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    public GameObject boomParticles;

    float damage = 1f;
    float speed = 15f;
    float radius = 5f;

    public void Update()
    {
        Vector3 temp = transform.forward * Time.deltaTime * speed;
        temp.y = 0f;
        transform.position += temp;
    }

    void OnCollisionEnter(Collision coll)
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.gameObject.transform.position, radius);
        List<GameObject> alreadyHit = new List<GameObject>();

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag != "Enemy" && hitColliders[i].gameObject.tag != null) { continue; }
            for (int j = 0; j < alreadyHit.Count; j++)
            {
                if (ReferenceEquals(hitColliders[i].gameObject.name, alreadyHit[j].name)) { continue; }
            }
            EventMaster.Instance.BulletImpact(damage, hitColliders[i].gameObject);
            alreadyHit.Add(hitColliders[i].gameObject);
            Debug.Log(hitColliders[i].gameObject.name);
        }

        Instantiate(boomParticles, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(this.gameObject);
    }
}
