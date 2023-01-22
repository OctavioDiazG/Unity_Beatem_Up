using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE, PUNCH_1, PUNCH_2, PUNCH_3, KICK_1, KICK_2
}

public class BEU_PlayerAttack : MonoBehaviour
{
    // Variables privadas
    private BEU_CharacterAnimation playerAnim; // Referencia del script de animacion

    private bool activateTimerToReset; // Se activo el tiempo para resetear el ataque

    private float defaultComboTimer = 0.4f; // Tiempo para terminar un combo
    private float currentComboTimer; // Tiempo actual para terminar el combo

    private ComboState currentComboState; // Estado actual del combo

    private void Awake()
    {
        playerAnim = GetComponentInChildren<BEU_CharacterAnimation>();
    }

    private void Start()
    {
        // Inicializar variables

        // Igualar el tiempo actual del combo con el valor default
        currentComboTimer = defaultComboTimer;

        // Estado inicial del combo
        currentComboState = ComboState.NONE;
    }

    private void Update()
    {
        // Llamada a la funcion para realizar combos
        ComboAttacks();

        // Llamada a la funcion que resetea el estado de combos
        ResetComboState();
    }

    // Funcion para realizar combos
    void ComboAttacks()
    {
        // Input de golpes
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Checar posibles estados actuales para finalizar el metodo
            if(currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_1 || currentComboState == ComboState.KICK_2)
            {
                // salir de la funcion (terminar combo)
                return;
            }

            // Aumentar el estado del combo
            // NONE -> PUNCH_1
            currentComboState++;

            // Activar el booleano que resetea el combo
            activateTimerToReset = true;

            // Actualizar tiempo actual del combo
            currentComboTimer = defaultComboTimer;

            // Animaciones de golpes
            // vamos a checar si nos encontramos en el estado punch1
            if(currentComboState == ComboState.PUNCH_1)
            {
                // Si es el caso llama al metodo PUNCH_1 del script de animaciones
                playerAnim.Punch_1();
            }

            // vamos a checar si nos encontramos en el estado punch2
            if (currentComboState == ComboState.PUNCH_2)
            {
                // Si es el caso llama al metodo PUNCH_2 del script de animaciones
                playerAnim.Punch_2();
            }

            // vamos a checar si nos encontramos en el estado punch3
            if (currentComboState == ComboState.PUNCH_3)
            {
                // Si es el caso llama al metodo PUNCH_3 del script de animaciones
                playerAnim.Punch_3();
            }
        }

        // Input de patadas
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Checar posibles estados actuales para finalizar el metodo
            if (currentComboState == ComboState.KICK_2 || currentComboState == ComboState.PUNCH_3)
            {
                // salir de la funcion (terminar combo)
                return;
            }

            // Checar posibles estados para realizar patadas
            if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH_1 || currentComboState == ComboState.PUNCH_2)
            {
                // Vamos a declarar que estamos en el estado Kick1 para hacer patadas y encadenar combos
                currentComboState = ComboState.KICK_1;
            }
            else if (currentComboState == ComboState.KICK_1)
            {
                // Aumentar el enum para llegar a kick2
                // Kick1 -> kick2
                currentComboState++;
            }

            // Activar timer para finalizar combo
            activateTimerToReset = true;

            // Actualizar el tiempo actual del combo
            currentComboTimer = defaultComboTimer;

            // Animaciones de patadas
            // Checar si nos encontramos en el estado kick1
            if(currentComboState == ComboState.KICK_1)
            {
                // Llamar al metodo kick_1 del script de animaciones
                playerAnim.Kick_1();
            }
            // Checar si nos encontramos en el estado kick2
            if (currentComboState == ComboState.KICK_2)
            {
                // Llamar al metodo kick_2 del script de animaciones
                playerAnim.Kick_2();
            }
        }
    }

    void ResetComboState()
    {
        // Checar si el timer para resetear el ataque esta activo
        if (activateTimerToReset)
        {
            // Reducir el tiempo actual de combo
            currentComboTimer -= Time.deltaTime;

            // Checar si el tiempo actual de combo ha terminado
            if (currentComboTimer <= 0f)
            {
                // Si es el caso, se nos acabo el tiempo para seguir el combo
                // Regresamos al estado default
                currentComboState = ComboState.NONE;

                // Desactivar el booleano para resetear el tiempo
                activateTimerToReset = false;

                // Nuevo valor de tiempo actual para el combo
                currentComboTimer = defaultComboTimer;
            }
        }
    }
}
