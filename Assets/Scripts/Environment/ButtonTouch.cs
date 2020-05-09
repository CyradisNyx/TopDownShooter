using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTouch : MonoBehaviour
{
    public List<GameObject> pressMe; // Who do I affect
    public List<GameObject> canPress; // Who can press me

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < canPress.Count; i++)
        {
            if (canPress[i] == collision.gameObject)
            {
                for (int j = 0; j < pressMe.Count; j++)
                {
                    pressMe[j].GetComponent<IPressable>().Press();
                }
            }
        }
    }
}
