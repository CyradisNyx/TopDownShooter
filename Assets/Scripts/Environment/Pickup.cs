using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pickup : MonoBehaviour
{
    public float turnDegrees;
    
    public enum pickupTypes
    {
        BasicGun,
    }
    public pickupTypes type;

    void Start()
    {
        if (type == pickupTypes.BasicGun)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/shittygun");
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, turnDegrees * Time.deltaTime, 0, Space.World);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name != "Player") { return; }

        if (type == pickupTypes.BasicGun)
        {
            EventMaster.Instance.Pickup("BasicGun");
        }

        Destroy(this.gameObject);

    }
}
