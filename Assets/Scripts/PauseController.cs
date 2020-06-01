using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject regularUI;
    public GameObject pauseUI;
    public GameObject settingsUI;
    public GameObject deathUI;

    public bool isPaused;
    public bool isDead;

    void Start()
    {
        EventMaster.Instance.onPause += Pause;
        EventMaster.Instance.onDeath += Death;
        isPaused = false;
        isDead = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("escape")) { EventMaster.Instance.Pause(!isPaused); }
    }

    public void Pause(bool isPaused)
    {
        this.isPaused = isPaused;

        if (isPaused == true)
        {
            pauseUI.SetActive(true);
            regularUI.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            regularUI.SetActive(true);
            pauseUI.SetActive(false);
            settingsUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Death(GameObject victim)
    {
        if (victim.tag == "Player")
        {
            regularUI.SetActive(false);
            StartCoroutine(DelayedDeath(2f));
        }
    }

    IEnumerator DelayedDeath(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        deathUI.SetActive(true);
        Time.timeScale = 0f;

        yield return null;
    }
}
