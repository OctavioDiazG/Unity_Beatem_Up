using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_ZombieScripts : MonoBehaviour
{
    [Header("Fx de Destruccion")]
    public GameObject bloodFXPrefab;

    [Header("Propiedades del zombie")]
    public float speed = 2f;

    private Rigidbody RB;

    private bool itsAlive;

    private ER_ScoreController score;

    public int puntos;
    private void Start()
    {

        RB = GetComponent<Rigidbody>();

        itsAlive = true;

        score = FindObjectOfType<ER_ScoreController>();
    }

    private void Update()
    {

        if(itsAlive)
        {

            RB.velocity = new Vector3(0f,0f,-speed);

        }

        if(transform.position.y < -10f)
        {
            DestroyGameObject();
        }

    }

    void Die()
    {
        score.IncScore(puntos);

        itsAlive = false;

        RB.velocity = Vector3.zero;

        GetComponent<Collider>().enabled = false;

        GetComponentInChildren<Animator>().Play("Idle");

        transform.rotation = Quaternion.Euler(90f,0f,0f);

        transform.localScale = new Vector3(1f,1f,0.2f);

        transform.position = new Vector3(transform.position.x,0.2f,transform.position.z);


    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision _other)
    {
        if(_other.gameObject.tag == "Player" || _other.gameObject.tag == "Bullet")
        {
            Instantiate(bloodFXPrefab,transform.position,Quaternion.identity);

            Invoke("DestroyGameObject",3f);

            Die();

        }
    }

}
