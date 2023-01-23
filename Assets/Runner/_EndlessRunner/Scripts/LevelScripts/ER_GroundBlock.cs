using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GroundBlock : MonoBehaviour
{

    [Header("Propiedades de Pieza de Terreno")]
    public Transform otherBlock;
    public float halfLenght = 100f;
    private Transform player;

    private float endOffset = 10f;




    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBlock();
    }

    void MoveBlock()
    {
        if(transform.position.z + halfLenght < player.transform.position.z - endOffset)
        {
            transform.position = new Vector3(otherBlock.position.x,otherBlock.position.y,otherBlock.position.z + halfLenght * 2);
        }
    }
}
