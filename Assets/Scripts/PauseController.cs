using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject regularUI;
    public GameObject pauseUI;

    public bool isPaused;

    void Start()
    {
        EventMaster.Instance.onPause += Pause;
        isPaused = false;
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
            Time.timeScale = 1f;
        }
    }
}
