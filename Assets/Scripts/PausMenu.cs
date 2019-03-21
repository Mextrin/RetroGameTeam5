using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Pause)) ;
        {
            Debug.Log("PAUSED");
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paus();
            }
        }
    }

    void Paus()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
