using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float turnDegrees;

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, turnDegrees * Time.deltaTime, 0, Space.World);
    }
}
