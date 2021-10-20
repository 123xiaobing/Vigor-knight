using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopControl : MonoBehaviour
{
    public GameObject pauseMenu;
    public void Stop()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
