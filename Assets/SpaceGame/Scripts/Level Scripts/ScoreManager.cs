using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video; //extension para para manejar escenas

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public LivesManager vida;
    public int puntosAumento;
    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        
        if(score >= puntosAumento)
        {
            vida.VidaExtra();
            puntosAumento += 10000;
        }

        scoreText.text = "" + score;
    }

    public static void AddPoints(int _pointstoAdd)
    { 
        score += _pointstoAdd;
        
        if (score >= 30000)
        {
            SceneManager.LoadScene("WinSceneSpace");
        }
    }
}