using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJugador : MonoBehaviour
{
    //variables publicas
    [Header("Velocidad de Bala")]
    public float speed = 6f;

    [Header("Tiempo de Destruccion de Bala")]
    public float destroyTimer = 3;

    [HideInInspector]
    public bool isEnemyBullet = false;

    private void Start()
    {//start start
        //checar si se trata de la bala de enemigo
        if (isEnemyBullet)
        {//start if
            //se agrega un valor negativo al valor de speed
            //esto es para que la bala se traslade de derecha a izquierda
            speed *= -1;
        }//end if 

        //invocar a la funcion de destruccion de bala
        //esto se activa despues de un tiempo
        Destroy(gameObject,destroyTimer);
    }//end start

    private void Update()
    {//start update
     //llamar a la funcion que mueve la bala
        Move();
    }//end update

    //funcion que mueve la bala
    void Move()
    {//start move
        //variable temporal que guarda la posicion de la bala
        Vector3 _temp = transform.position;

        //adicion de la posicion temporal en x
        //disparar de izquierda a derecha
        _temp.x += speed * Time.deltaTime;

        //actializar la posicion de bala usando el vector temporal
        transform.position = _temp;
    }//end move

    //funcion poara destriur la bala cuando sale de la pistola

    //funcion para evualar entrada de un objeto a un trigger 2d
    private void OnTriggerEnter2D(Collider2D _other)
    {//start ontriggerenter2d
        //vamos a checar si el objeto entrante tiene tags especificos
        //checar si se trata del tag "bullet" o "enenmy"
        if(_other.tag == "EnemyBullet" || _other.tag == "Enemy")
        {//start if
            //llamar a la funcion que destruye la bala
            Destroy(gameObject);
        }//end if
    }//end ontriggerenter2d
}
