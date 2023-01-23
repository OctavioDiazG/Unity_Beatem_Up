using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SIU_PlayerInteractions : MonoBehaviour
{

    private Rigidbody RB;

    private bool playerDied;

    private SIU_CameraFollow cameraFollow;

    public GameObject winScreen;

    private void Awake()
    {
        RB = GetComponent<Rigidbody>();

        cameraFollow = Camera.main.GetComponent<SIU_CameraFollow>();

        winScreen = GameObject.FindGameObjectWithTag("WIN");
        
        winScreen.SetActive(false);
    }


    private void Update()
    {
        if(!playerDied)
        {
            if (RB.velocity.sqrMagnitude > 60)
            {
                playerDied = true;

                cameraFollow.CanFollow = false;

                SIU_SoundManager.instance.GameEndSound();

                SIU_GameplayController.instance.RestartGame();

            }
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(_other.CompareTag("Coin"))
        {
            Destroy(_other.gameObject);

            SIU_GameplayController.instance.AddScore();

            SIU_SoundManager.instance.PickUpCoin();

        }

        if(_other.CompareTag("Spike"))
        {
            cameraFollow.CanFollow = false;

            Destroy(gameObject);

            SIU_SoundManager.instance.GameEndSound();

            SIU_GameplayController.instance.RestartGame();

        }
    }

    private void OnCollisionEnter(Collision _other)
    {

        if(_other.gameObject.CompareTag("EndPlatform"))
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
        
    }
    
    



}
