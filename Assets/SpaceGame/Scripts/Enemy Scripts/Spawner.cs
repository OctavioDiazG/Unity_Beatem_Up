using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{//start class
    [Header("Limites en Y")]
    public float minY = -5.1f;
    public float maxY = 5.1f;

    [Header("Asignacion de enemigos")]
    public GameObject[] asteroidPrefabs;//arreglos de asteroides
    public GameObject[] enemyShipPrefab;//GO de nave enemiga

    [Header("Timer de Generacion")]
    public float timer = 2f;//tiempo de aparicion de enemigos
    private void Start()
    {//start start
        //invocacion de funcion para generar enemigos
        //estos aparecen al inicio del juego
        Invoke("SpawnEnemies", timer);
    }//end start

    //metodo para generar enemigos
    void SpawnEnemies()
    {//start spawnenemies
        //vamos a crear una posicion local aleatoria tomando en cuenta los limites de y
        float _posY = Random.Range(minY, maxY);

        //valor local que guarda la posicion del generador
        Vector3 _temp = transform.position;

        //igualar la posicion temporal en y con la posicion local en y
        _temp.y = _posY;

        //vamos a evaluar un rango aleatorio para generar enemigos
        if(Random.Range(0,2) > 0)
        {//start if
            //esto es si el valor es 1
            //si es el caso, instanciamos un asteroide del array
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], _temp, Quaternion.identity);
        }//end if
        else
        {//start else
            //esto es si el random es 0
            //instanciamos la nave enemiga
            Instantiate(enemyShipPrefab[Random.Range(0, enemyShipPrefab.Length)], _temp, Quaternion.Euler(0f, 0f, 90f));
        }//end else

        //invocacion de funcion para generar enemigos usando un temporizador
        Invoke("SpawnEnemies", timer);
    }//end spawnenemies
}//end class
