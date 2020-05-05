using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    float damage = 2f;
    float speed = 25f;

    public void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
