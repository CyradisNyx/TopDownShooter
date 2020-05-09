using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    Rigidbody rb;
    Vector3 movement;
    bool moving;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = 0f;
        this.movement.z = Input.GetAxisRaw("Vertical");

        if (movement != new Vector3(0f, 0f, 0f)) { moving = true; }
        else { moving = false; }

        this.gameObject.transform.Find("RightSide").GetComponent<Animator>().SetBool("Moving", moving);
        this.gameObject.transform.Find("LeftSide").GetComponent<Animator>().SetBool("Moving", moving);
    }

    void FixedUpdate()
    {
        //Move
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
