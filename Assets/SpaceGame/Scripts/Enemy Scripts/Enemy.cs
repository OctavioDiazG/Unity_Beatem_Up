using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{//start class
    //variables publicas
    [Header("Velocidades de Enemigo")]
    public float speed = 5f; //velocidad del enemigo
    public float rotateSpeed = 50f; //velocidad de rotacion de la nave enemiga

    [Header("Propiedades de Enemigo")]
    public bool canShoot; //Dice si el enemigo puede disparar o no
    public bool canRotate; //Dice si el enemigo puede rotar o no

    public bool canMove = true; //Dice si el enemigo se puede mover o no

    [Header("Limite de Enemigo")]
    public float boundX = -10f; //Limite de avance de enemigo en -x

    [Header("Asignaciones")]
    public Transform[] attackPoint;//de donde dispara el enemigo
    public GameObject bulletPrfab; //referencia al gameobject de la bala enemiga

    //variables privadas
    private Animator anim;//referencia del componente animator del enemigo
    private AudioSource explosionSound; //referencia al componente audiosource del enemigo

    public ScoreManager ScoreManager;
    public int points;


    private void Awake()
    {//start awake
        //inicializar referencias
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
        ScoreManager = FindObjectOfType<ScoreManager>();
        
    }//end awake

    private void Start()
    {//start start
        //checar si el enemigo puede rotar
        if (canRotate)
        {//start if 
            rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            //Randomizar una rotacion
            if (Random.Range(0, 2) > 0)
            {//start if2
                //Esto es si el random vale 1
                //primera vallor de velocidad de rotacion
                //rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);

                //cambio de sentido a la rotacion
                rotateSpeed *= -1f;
            }//end if2
            /*
            else
            {//start else2
                //esto pasa cuando el random inicial sale 0

                //declarar una nueva velocidad de rotacion al enemigo\
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
            }//end else2
            */
        }//end if
        //checar si el enemigo puede disparar
        if (canShoot)
        {//start if
            //si es el caso, vamos a invocar el metodo de disparos en un tiempo aleatorio
            Invoke("StartShooting", Random.Range(1f, 3f));
        }//end if
    }//end start

    private void Update()
    {//start update
        //llamada al metodo de movimiento de los enemigos
        MoveEnemy();
        //llamada al metodo de las rotaciones de los asteroides
        RotateEnemy();
    }//end update

    //metodo de movimiento de las naves enemigas
    void MoveEnemy()
    {//start moveEnemy
        //checar si el enemigo se puede mover
        if (canMove)
        {//start if
            //variable que guarda la posicion actual del enemigo
            Vector3 _temp = transform.position;

            //decremento de la pos x del enemigo usando el tiempo
            _temp.x -= speed * Time.deltaTime;

            //actualizar la posicion  de este objeto usando el vector temp
            transform.position = _temp;

            //validar el limite de -x de la posicion del enemigo
            //checar si el valor del _temp en x es menor al valor de limite en x
            if (_temp.x < boundX)
            {//start if2
                //destruir al gameobject que tiene este script
                Destroy(gameObject);
            }//end if2
        }//end if
    }//end moveEnemy

    //metodo para rotar enemigo
    void RotateEnemy()
    {//start rotateEnemy
        //checar si el enemigo puede rotar
        if (canRotate)
        {//start if
            //aplicar la rotacion con respecto al mundo
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }//end if
    }//end rotateenemy

    //metodo de disparo
    void StartShooting()
    {//start startshooting
        //guardar la instancia de la bala dentro de una variable
        for (int i = 0; attackPoint.Length > i; i++)
        {
            GameObject _bullet = Instantiate(bulletPrfab, attackPoint[i].position, Quaternion.identity);

            //acceder a la variable isEnemyBullet de bullet para cambiar la direccion del disparo
            //vamos a acceder al componente ssbullet de la bala para cambiar valor de direccion
            _bullet.GetComponent<Bullet>().isEnemyBullet = true;
        }

        //checar si el enemigo puede disparar
        if(canShoot)
        {//start if
            //si es el caso, se invoca este metodo usando un tiempo aleatorio
            Invoke("StartShooting", Random.Range(1f, 3f));
        }//end if
    }//end startshooting

    //Metodo que evalua la entrada de un objeto a un trigger 2d
    private void OnTriggerEnter2D(Collider2D _other)
    {//start ontriggerenter2d
        //checar si el objeto entrante tiene el tag de bullet
        if(_other.tag == "Bullet")
        {//start if\
            //si una bala choca contra el enemig, este no se pude mover
            canMove = false;

            //Vamos a checar si el enemigo puede disparar
            if (canShoot)
            {//start if2
                //el enemigo ya no puede disparar
                canShoot = false;
                //se deja de invocar el metodo de disparo
                CancelInvoke("StartShooting");
            }//end if2

            //desactuvar collider de enemigo
            GetComponent<Collider2D>().enabled = false;
            //invocar al metodo de destruccion de objetos despues de 3s
            Destroy(gameObject,3f);

            //reproducir sonido de explosion
            explosionSound.Play();

            //animacion de destruccion del enemigo
            anim.Play("Enemy_Explode");

            ScoreManager.AddPoints(points);

        }//end if

        //checar si el objeto entrante es el jugador
        if(_other.tag == "Player")
        {//start if
            //llamar a la funcion de reaparicion de jugador usando el singleton de levelmanager
            LevelManager.instance.RespawnPlayer();

        }//end if

    }//end ontriggerenter2d

}//end class
