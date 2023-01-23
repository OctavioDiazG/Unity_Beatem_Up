using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SIU_GameplayController : MonoBehaviour
{
    public static SIU_GameplayController instance;

    public Text scoretext;

    private int score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddScore()
    {
        score++;
        scoretext.text = "x" + score;
        

    }

    public void RestartGame()
    {
        Invoke("ReloadScene", 3f);
        SIU_SoundManager.instance.GameStartSound();
    }

    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SIU_Playground");
    }


}
