using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_PlayerMovement : MonoBehaviour
{
    // Variables publicas
    public float walkspeed = 2f; // Velocidad del jugador al caminar
    public float zSpeed = 1.5f; // Velocidad en z del jugador

    // Variables privadas
    private Rigidbody RB; // Referencia del componente RB del jugador

    private BEU_CharacterAnimation playerAnim; // Referencia del script de animaciones del personaje

    private float rotationY = -90f; // Rotacion del personaje al iniciar el juego
    private float rotationSpeed = 15f; // Velocidad de rotacion

    private void Awake()
    {
        // Inicializacion de referencias
        RB = GetComponent<Rigidbody>();

        playerAnim = GetComponentInChildren<BEU_CharacterAnimation>();
    }

    private void Update()
    {
        // Llamar a la funcion para rotar al jugador
        RotatePlayer();

        // Llamar a la funcion para animar el movimiento del jugador
        AnimatePlayerWalk();
    }

    private void FixedUpdate()
    {
        // Llamada a la funcion que detecta el movimiento del jugador
        DetectMovement();
    }

    // Funcion para detectar el movimiento del jugador
    void DetectMovement()
    {
        // Vamos a manejar la velocidad del RB por medio de inpus
        // Inputs para mover a jugador
        RB.velocity = new Vector3(Input.GetAxisRaw(BEU_Axis.HORIZONTAL_AXIS) * (-walkspeed), RB.velocity.y, Input.GetAxisRaw(BEU_Axis.VERTICAL_AXIS) * (-zSpeed));
    } 

    // Funcion para rotar al jugador
    void RotatePlayer()
    {
        // Checar si el jugador se mueve a la derecha
        if (Input.GetAxisRaw(BEU_Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }

        // Checar si el jugador se mueve a la izquierda
        else if (Input.GetAxisRaw(BEU_Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotationY), 0f);
        }
    }

    // Metodo que maneja la animacion de caminado del jugador
    void AnimatePlayerWalk()
    {
        // Vamos a checar si el jugador esta presionando inputs de movimiento
        // El jugador se encuentra en movimiento
        if(Input.GetAxisRaw(BEU_Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(BEU_Axis.VERTICAL_AXIS) != 0)
        {
            // Vamos a llamar al metodo que cambia el bool de movement
            playerAnim.Walk(true);
        }
        else
        {
            // No hay inputs de movimiento por lo tanto el jugador no se esta moviendo
            playerAnim.Walk(false);
        }
    }
}
