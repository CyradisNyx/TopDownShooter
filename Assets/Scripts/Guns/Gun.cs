using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Sprite gunSprite;
    public virtual string SpriteFile { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        gunSprite = Resources.Load<Sprite>(SpriteFile);
        GetComponent<Image>().sprite = gunSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
