using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_Bullet : MonoBehaviour
{

    [SerializeField]
    private Rigidbody RB;


    public void MoveBullet(float _speed)
    {

        RB.AddForce(transform.forward.normalized * _speed);

        Invoke("DestroyGOs",5f);



    }

    void DestroyGOs()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision _other)
    {
        if(_other.gameObject.tag == "Obstacle")
        {
            DestroyGOs();
        }
    }

}
