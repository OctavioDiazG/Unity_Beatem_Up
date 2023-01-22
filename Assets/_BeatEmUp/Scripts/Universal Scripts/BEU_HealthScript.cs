using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEU_HealthScript : MonoBehaviour
{
    //Variables publicas
    public float healt = 100f; //Cantidad de vida del personaje
    public bool isPlayer; //El jugador tiene este script como componente Y/N?

    //Variables Privadas
    private BEU_CharacterAnimation animationScript;
    private BEU_EnemyMovement enemyMovement;
    private bool characterDied; //El personaje esta muerto Y/N?

    private BEU_HealtUi salud;

    private void Awake()
    {
        //Inicializaci�n de referencia de CharacterAnimation
        animationScript = GetComponentInChildren<BEU_CharacterAnimation>();
        if (isPlayer)
        {
            salud = GetComponent<BEU_HealtUi>();
        }
    }

    //Metodo para aplicar da�o
    public void ApplyDamage(float _damage, bool _knockdown)
    {
        //Checar si el personaje esta muerto
        if (characterDied)
            //Si esto aplica, salimos de la funci�n
            return;

        //Reducir vida usando el parametro local de da�o
        healt -= _damage;
        if (isPlayer)
        {
            salud.DisplayHealth(healt);
        }
        //Mostrar UI de vida

        //Condicional de muerte del personaje
        //Checar si la cantidad de vida es 0 o menor
        if(healt <= 0)
        {
            //Llamar al metodo de muerte del script CharacterAnimation
            animationScript.Death();

            //El personaje se muere
            characterDied = true;

            //Checar si quien muere es el jugador
            if(isPlayer)
            {
                //Desactivar el Script de Enemigo!
                GameObject.FindWithTag(BEU_Tags.PLAYER_TAG)
                    .GetComponent<BEU_PlayerMovement>().enabled = false;
            }

            //Salida de funcion
            return;
        }

        //Checar si quien tiene este script NO es el jugador
        //Vamos a cehcar que le enemigo tenga este script
        if(!isPlayer)
        {
            //Checar el valor del parametro al enemigo
            if(_knockdown)
            {
                //Si el parametro es true, tendremos un rango aleatorio para
                //llamar a la animacion Knockdown del Enemigo
                //El jugador tendra 50% de probabilidad de noquear al enemigo
                if(Random.Range(0, 4) > 2)
                {
                    //Llamar al metodo de noqueo del script de animaciones
                    animationScript.Knockdown();
                }
            }
            else 
            { 
                //Esto aplica cuando el parametro de noqueo es falso

                //Rango aleatorio para llamar a la animacion de impacto del enemigo
                //33% de probabilidad para llamar a dicha animacion
                if(Random.Range(0, 3) > 1)
                {
                    //Llamar al metodo de impacto dentro del Script de animaciones
                    animationScript.Hit();
                }
            }
        }
    }
}
