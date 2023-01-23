using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{//Starts class
    //Variables Publicas
    public float scrollSpeed = 0.1f; //Velociada de scrolling

    //variables privadas
    private MeshRenderer meshRenderer; // ref del componente mesh renderer del background

    private float xScroll; //valor del scrolling en el eje x en el unity

    private void Awake()
    {//Start Awake
        //inicializar la ref meshrenderer
        meshRenderer = GetComponent<MeshRenderer>();
    }//End Awake

    private void Update()
    {//Start update
        //llamar al metodo para scrollear el background
        Scroll();
    }//End update

    void Scroll()
    {//Start scroll
        //Determinar el valor de scroll usando la velocidad y el tiempo
        xScroll = Time.time * scrollSpeed;

        //Determinar el desplazamiento al scrollear
        //Este va a ser un valor local :D
        Vector2 _offest = new Vector2(xScroll, 0.0f);

        //Modificar Textura usando el offset
        //Aqui pasaremos el nombre generico de la textura y se agrega dicho offset
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", _offest);
    }//End scroll

}//Ends class
