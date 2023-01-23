using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ER_PlayerController : ER_BaseController
{//START CLASS ER_PlayerController

    [Header("Propiedades de disparo")]
    public Transform bulletStartPoint;
    public GameObject bulletPrefab;
    public ParticleSystem shootFX;

    [HideInInspector]
    public bool canShoot;

    //Variables Privadas
    private Rigidbody RB; //REF COMP Rigidbody del Jugador

    private Animator shootSliderAnim;

    private void Start()
    {//START Start
        //Inicializar la referencia RB
        RB = GetComponent<Rigidbody>();

        shootSliderAnim = GameObject.Find("UI_SLD_FireBar").GetComponent<Animator>();

        GameObject.Find("UI_BTN_ShootBtn").GetComponent<Button>().onClick.AddListener(ShootingControl);

        canShoot = true;



    }//END Start

    private void Update()
    {
        ControlMovementWithKeyboard();

        ChangeRotation();
        //ShootingControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer() 
    {

        RB.MovePosition(RB.position + speed * Time.deltaTime);

    }

    void ControlMovementWithKeyboard()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveSlow();
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            MoveStraight();
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            MoveStraight();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            MoveNormal();
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveNormal();
        }
    }

    void ChangeRotation()
    {
        if(speed.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);

        }
        else if(speed.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }

    public void ShootingControl()
    {
        if(Time.timeScale != 0)
        {
            if(canShoot)
            {
                GameObject _bullet = Instantiate(bulletPrefab,bulletStartPoint.position,Quaternion.identity);

                _bullet.GetComponent<ER_Bullet>().MoveBullet(2000f);

                shootFX.Play();

                canShoot = false;

                shootSliderAnim.Play("Anim_ShootBar_FadeIn");

            }
        }
    }


}//END CLASS ER_PlayerController
