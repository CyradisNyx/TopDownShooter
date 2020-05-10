using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite fullHealth;
    public Sprite emptyHealth;
    public int numPerRow;

    TakeDamage playerHealth;
    List<GameObject> hearts = new List<GameObject>();

    public void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            hearts.Add(gameObject.transform.GetChild(i).gameObject);
        }

        playerHealth = GameObject.Find("Player").GetComponent<TakeDamage>();

        UpdateBar();
    }

    void Update()
    {
        UpdateBar();
    }

    void UpdateBar()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < playerHealth.getHealth()) { hearts[i].GetComponent<Image>().sprite = fullHealth; }
            else { hearts[i].GetComponent<Image>().sprite = emptyHealth; }
        }
    }
}
