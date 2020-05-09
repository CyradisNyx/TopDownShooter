using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite fullHealth;
    public Sprite emptyHealth;
    public int numPerRow;

    float health;
    List<GameObject> hearts = new List<GameObject>();

    public void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            hearts.Add(gameObject.transform.GetChild(i).gameObject);
        }

        EventMaster.Instance.onBulletImpact += BulletImpact;
        this.health = GameObject.Find("Player").GetComponent<TakeDamage>().health;

        UpdateBar();
    }

    public void BulletImpact(float damage, GameObject coll)
    {
        if (coll.name != "Player") { return; }
        this.health -= damage;

        UpdateBar();
    }

    void UpdateBar()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < health) { hearts[i].GetComponent<Image>().sprite = fullHealth; }
            else { hearts[i].GetComponent<Image>().sprite = emptyHealth; }
        }
    }
}
