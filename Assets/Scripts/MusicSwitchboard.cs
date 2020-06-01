using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitchboard : MonoBehaviour
{
    AudioSource audioBoi;

    public AudioClip BackgroundMusic;
    public AudioClip DeathMusic;

    void Start()
    {
        audioBoi = this.gameObject.GetComponent<AudioSource>();
        audioBoi.clip = BackgroundMusic;
        EventMaster.Instance.onDeath += Death;
    }

    public void Death(GameObject victim)
    {
        if (victim.tag == "Player")
        {
            audioBoi.clip = DeathMusic;
            audioBoi.Stop();
            audioBoi.Play();
        }
    }
}
