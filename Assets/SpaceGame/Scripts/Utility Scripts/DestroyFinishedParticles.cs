using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticles : MonoBehaviour
{//start class de destroyfinishedparticles
    //variables privadas
    //referencia de particles
    private ParticleSystem thisParticleSystem;
    private void Start()
    {//start start
        //inicializar la ref thisparticle
        thisParticleSystem = GetComponent<ParticleSystem>();
    }//end start

    private void Update()
    {//start update
        //llamar a la funcion para destruir particulas
        DestroyParticles();
    }//end  update

    void DestroyParticles()
    {//start destroyparticles
        //checar si el emisor de particulas esta en reproducion
        if (thisParticleSystem.isPlaying)
        {//start if
            //si es el caso, la funcion sigue
            return;
        }//end if
        else
        {//start else
            //destruir el objeto que tiene este script
            Destroy(gameObject);
        }//end else

    }
}//end class de destroyfinishedparticles
