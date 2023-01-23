using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_BaseController : MonoBehaviour
{//START CLASS ER_BaseController
    //Variables Publicas
    [Header("Vector de Velocidad")]
    public Vector3 speed; //Vector de velocidad del jugador

    [Header("Valores de Velocidad")]
    public float xSpeed = 8f; //Velocidad del movimiento lateral del jugador
    public float zSpeed = 15f; //Velocidad del movimiento hacia adelante del jugador

    [Header("Features de Movimiento")]
    public float acceleration = 30f; //Valor de aceleracion
    public float deceleration = 10f; //Valor para bajar la velocidad

    protected float rotationSpeed = 10f; //Velocidad de rotacion          //PROTECTED = Privada pero usable por una clase hija
    protected float maxAngle = 10f; //Angulo maximo al que el jugador puede rotar

    [Header("Valores de Pitch de Audio")]
    public float lowSoundPitch; //Valores para influenciar los audios
    public float normalSoundPitch;
    public float highSoundPitch;

    [Header("Clips de Audio")]
    public AudioClip engine_OnSound; //Sonido de encendido, motor constante
    public AudioClip engine_OffSound; //Sonido de bajar velocidad/apagar

    //Variables Privadas
    private bool isSlow; //El jugador va lento? Y/N

    private AudioSource soundManager; //REF COMP AudioSource del Jugador

    private void Awake()
    {//START Awake
        //Valor inicial de la REF soundManager
        soundManager = GetComponent<AudioSource>();

        //Valor inicial del vector de velocidad
        speed = new Vector3(0f, 0f, zSpeed);
    }//END Awake

    //Metodo protegido para mover al jugador a la IZQUIERDA
    protected void MoveLeft() 
    {//START MoveLeft
        //Cambiar el valor de speed para mover al Jugador a la izquierda
        speed = new Vector3(-xSpeed / 2f, 0f, speed.z); 
    }//END MoveLeft

    //Metodo protegido para mover al jugador a la DERECHA
    protected void MoveRight()
    {//START MoveRight
        //Cambiar el valor de speed para mover al Jugador a la derecha
        speed = new Vector3(xSpeed / 2f, 0f, speed.z);
    }//END MoveRight

    //Metodo protegido para mover al jugador DERECHO
    protected void MoveStraight()
    {//START MoveStraight
        //Cambiar el valor de speed para mover al Jugador hacia adelante
        speed = new Vector3(0f, 0f, speed.z);
    }//END MoveStraight

    //Metodo protegido para declarar la velocidad normal del jugador
    protected void MoveNormal()
    {//START MoveNormal
        //Vamos a checar si el Jugador va lento
        if (isSlow) 
        {//START IF
            //Va a dejar de ir lento, cambio de valor al bool isSlow
            isSlow = false;

            //Detener el audioSource del jugador
            soundManager.Stop();

            //Cambiar el clip del audioSource del Jugador
            soundManager.clip = engine_OnSound;

            //Cambiar el volumen del audioSource
            soundManager.volume = 0.3f;

            //Reproducir audioSource
            soundManager.Play();
        }//END IF

        //Declarar el vector de velocidad normal
        speed = new Vector3(speed.x, 0f, zSpeed);
    }//END MoveNormal

    //Metodo protegido para declarar la velocidad reducida del jugador
    protected void MoveSlow()
    {//START MoveSlow
        //Vamos a checar si el Jugador NO va lento
        if (!isSlow)
        {//START IF
            //Va a ir lento, cambio de valor al bool isSlow
            isSlow = true;

            //Detener el audioSource del jugador
            soundManager.Stop();

            //Cambiar el clip del audioSource del Jugador
            soundManager.clip = engine_OffSound;

            //Cambiar el volumen del audioSource
            soundManager.volume = 0.3f;

            //Reproducir audioSource
            soundManager.Play();
        }//END IF

        //Declarar el vector de velocidad reducida
        speed = new Vector3(speed.x, 0f, deceleration);
    }//END MoveNormal

    //Metodo protegido para la velocidad acelerada del Jugador
    protected void MoveFast()
    {//START MoveFast
        //Declarar el vector de velocidad acelerada
        speed = new Vector3(speed.x, 0f, acceleration);
    }//END MoveFast
}//END CLASS ER_BaseController
