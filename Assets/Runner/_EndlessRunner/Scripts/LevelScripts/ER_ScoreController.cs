using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ER_ScoreController : MonoBehaviour
{
    public Text ScoreText;
    public GameObject winScreen;
    public int Score = 0;
    public void IncScore(int _add)
    {
        Score += _add;
        if(Score >= 100)
        {
            win();
        }
    }

    void Update()
    {
        ScoreText.text = "Score: " + Score;
    }

    void win()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);
    }
}
