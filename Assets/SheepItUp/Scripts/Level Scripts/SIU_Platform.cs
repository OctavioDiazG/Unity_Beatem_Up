using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // Extension para usar DOTween

public class SIU_Platform : MonoBehaviour
{

    [Header("Arreglo de Picos")]
    [Tooltip("Aqui añades todos los Obstaculos deseados para el videojuego")]
    [SerializeField]
    private Transform[] spikes;

    [Header("Colectables")]
    [Tooltip("Aqui usas el Prefab de la moneda que recolecta el jugador")]
    [SerializeField]
    private GameObject coinPrefab;

    private bool fallDown;


    private void Start()
    {
        activatePlatform();
    }

    void activateSpyke()
    {
        //  Random Index for the obstacles
        int _index = Random.Range(0, spikes.Length);
        //  Activate the spykes
        spikes[_index].gameObject.SetActive(true);
        // "Animate the Spykes"
        spikes[_index]
            .DOLocalMoveY(0.6f, 1.4f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(Random.Range(4f, 6f));

    }

    void addCoins()
    {
        //print the coin
        GameObject _coin = Instantiate(coinPrefab);
        //coordinates of the coin
        _coin.transform.position = transform.position;
        //Parent the coin
        _coin.transform.SetParent(transform);
        //Move Coin Upwards using DOTween
        _coin.transform.DOLocalMoveY(1f, 0f);

    }

    void activatePlatform()
    {
        //Random Float to Generate a number in between 0 & 100
        //this value will be a percentage
        int _chance = Random.Range(0, 100);

        //check if the float is > 70 
        // this will make that the platforms with no obstacles are 30%
        //this value can change to add more features in the platforms 

        if(_chance > 70)
        {
            //determinate the type of platform
            // the type of platform will be based on a random float
            int _type = Random.Range(0, 8);
            // _Type Statements

            if(_type == 0) { activateSpyke(); }
            else if (_type == 1) { addCoins(); }
            else if (_type == 2) { fallDown = true; }
            else if (_type == 3) { addCoins(); }
            else if (_type == 4) { activateSpyke(); }
            else if (_type == 5) { addCoins(); }
            else if (_type == 6) { fallDown = true; }
            else if (_type == 7) { activateSpyke(); }


        }
    }

    void invokeFalling()
    {
        //Add a RigidBody Component so the platform can fall down
        gameObject.AddComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision _other)
    {
        //check if the object that colides with the platform as the tag Player
        if(_other.gameObject.CompareTag("Player"))
        {
            //check if the fallDown Bool is True
            if(fallDown)
            {
                //change the bool to false
                fallDown = false;

                Invoke("invokeFalling", 2f);

            }

        }
    }







}
