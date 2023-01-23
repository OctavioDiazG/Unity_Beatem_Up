using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ER_Pause : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Pause()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void unPause()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
