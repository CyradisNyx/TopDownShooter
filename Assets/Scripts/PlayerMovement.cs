using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody rb;
    Vector3 movement;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = 0f;
        this.movement.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Move
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
