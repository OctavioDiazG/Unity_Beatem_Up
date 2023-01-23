using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{//Start class
    //variables publicas
    [Header("Velocidad de player")]
    public float speed = 5f; //Velocidad del jugador

    [Header("Limites en Y")]
    public float minY; //limites minimos del mapa
    public float maxY; //limites maximo del mapa

    [Header("Delay de disparo")]
    public float attackTimer = 0.4f; //timepo de dispar

    //variables privadas 
    [SerializeField]
    private GameObject playerBullet; //Referencia al gameobject de la bala del jugador

    [SerializeField]
    private Transform attackPoint; //punto de origen de los disparos

    private float currentAttackTimer;//Tiempo de ataque actual 

    private bool canAttack; //para saber si el jugador puede disparar

    private AudioSource laserSound;

    private void Awake()
    {//START AWAKE
        //inicializacion de referencia
        laserSound = GetComponent<AudioSource>();
    }//END AWAKE

    private void Start()
    {//start start
        //declaracion del tiempo de ataque actual
        currentAttackTimer = attackTimer;
    }//end start

    private void Update()
    {//start update
        //llamar a la funcion que mueve al jugaor
        MovePlayer();

        //llamar a la funcion de ataque
        Attack();
    }//end update

    //funcion que mueve al jugador

    void MovePlayer()
    {//start moveplayer
        //movimiento en vertical
        //checar si el valor del eje vertical es mayor a 0
        if (Input.GetAxisRaw("Vertical") > 0f)
        {//start if
            //crear variable temporal que guarda la posicion del player
            Vector3 _temp = transform.position;

            //Declara el valor en y del vector temporal para ascender
            //usaremos el valor de speed y el delta para aumentar posicion
            _temp.y += speed * Time.deltaTime;

            //Limitar el movimiento superior en Y
            if (_temp.y > maxY)
                _temp.y = maxY;

            //asignar la transformacion
            //actualizar la posicion del jugador usando los valores temporales
            transform.position = _temp;
        }//end if
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {//start else if
             //crear variable temporal que guarda la posicion del player
                Vector3 _temp = transform.position;

                //Declara el valor en y del vector temporal para decender
                //usaremos el valor de speed y el delta para aumentar posicion
                _temp.y -= speed * Time.deltaTime;

                //Limitar el movimiento superior en Y
                if (_temp.y < minY)
                    _temp.y = minY;

                //asignar la transformacion
                //actualizar la posicion del jugador usando los valores temporales
                transform.position = _temp;
            }//end else if
    }//end moveplayer

    //funcion de ataque
    void Attack()
    {//start attack
        //adicion de tiempo de ataque
        attackTimer += Time.deltaTime;

        //evaluacion de los tiempos de ataque
        //checar si el tiempo de ataque es mayor al default
        if (attackTimer > currentAttackTimer)
        {//start if
            //el jugador puede disparar
            canAttack = true;
        }//end if

        //input de disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {//start if
            //checar si el jugador puede atacar :D
            if (canAttack)
            {//start if2
                //cuando se pueda atacar se va a pausar el ataque para que no lo spamee
                //evitar el spam del jugador
                canAttack = false;

                //se resetea el tiempo de ataque UWU
                attackTimer = 0f;

                //instanciar la bala del jugador
                Instantiate(playerBullet, attackPoint.position, Quaternion.identity);

                //reproducir el sonido de la bala si quieres uwu
                laserSound.Play();

            }//start if2
        }//end if
    }

}//End class
