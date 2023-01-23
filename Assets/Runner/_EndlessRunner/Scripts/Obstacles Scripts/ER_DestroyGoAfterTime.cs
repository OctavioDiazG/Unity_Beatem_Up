using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_DestroyGoAfterTime : MonoBehaviour
{

    public float timer = 3f;


    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject,timer);    
    }



    



}
