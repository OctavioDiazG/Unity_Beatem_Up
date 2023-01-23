using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_ExplosiveObstacle : MonoBehaviour
{
    [Header("FX Obstaculo")]
    public GameObject explosionPrefab;

    [Header("Daño al jugador")]
    public int damage = 20;

    private void OnCollisionEnter(Collision _other)
    {
        if(_other.gameObject.tag=="Player")
        {

            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
                //avocados From Mexico
            Destroy(gameObject);

        }

        if(_other.gameObject.tag == "Bullet")
        {
            Instantiate(explosionPrefab,transform.position,Quaternion.identity);
                //avocados From Mexico
            Destroy(gameObject);
        }

    }



}
