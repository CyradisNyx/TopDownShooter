using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementCredits : MonoBehaviour
{
    public float movementSpeed = 5f;

    Rigidbody2D rb;
    Vector2 movement;
    bool moving;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(0);
        }

        // Input handling
        this.movement.x = Input.GetAxisRaw("Horizontal");
        this.movement.y = Input.GetAxisRaw("Vertical");

        if (movement != new Vector2(0f, 0f)) { moving = true; }
        else { moving = false; }

        this.gameObject.transform.Find("RightSide").GetComponent<Animator>().SetBool("Moving", moving);
        this.gameObject.transform.Find("LeftSide").GetComponent<Animator>().SetBool("Moving", moving);
    }

    void FixedUpdate()
    {
        // Physics-related, movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
