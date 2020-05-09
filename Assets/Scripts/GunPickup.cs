using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunPickup : MonoBehaviour
{
    public float turnDegrees;
    public Sprite gunSprite;

    void Start()
    {

    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, turnDegrees * Time.deltaTime, 0, Space.World);
    }

    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
