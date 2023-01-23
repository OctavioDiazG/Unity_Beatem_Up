using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIU_SoundManager : MonoBehaviour
{
    public static SIU_SoundManager instance;

    [SerializeField]
    private AudioSource gameStart, gameEnd, coinSound, jumpSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void GameStartSound()
    {
        gameStart.Play();
    }

    public void GameEndSound()
    {
        gameEnd.Play();
    }

    public void PickUpCoin()
    {
        coinSound.Play();
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }


}
