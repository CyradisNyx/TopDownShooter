using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBurst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventMaster.Instance.onDeath += Death;
    }

    public void Death(GameObject victim)
    {
        if (victim != this.gameObject) { return; }

        Destroy(this.gameObject);
    }
}
