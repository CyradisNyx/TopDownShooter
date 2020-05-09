using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPressable
{
    public float movementSpeed = 3f;
    protected bool locked = false;
    protected bool raised = true;

    public void Press()
    {
        if (!locked)
        {
            locked = true;
            StartCoroutine(Move(raised));
        }
    }

    IEnumerator Move(bool lower)
    {
        Vector3 goTo;
        float elapsedTime = 0;

        if (lower) { goTo = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z); }
        else { goTo = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z); }
        
        while (elapsedTime < movementSpeed)
        {
            transform.position = Vector3.Lerp(transform.position, goTo, (elapsedTime / this.movementSpeed));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = goTo;

        this.locked = false;
        this.raised = !this.raised;

        yield break;
    }
}
