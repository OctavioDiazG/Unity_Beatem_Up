using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //extencion para usar elementos de ui
using UnityEngine.SceneManagement; //extension para para manejar escenas

public class LivesManager : MonoBehaviour
{//start class livesmanager

    //Variables Publicas
    public static LivesManager instance; //variable Singleton

    [Header("Vidas de Jugador")]
    public int startingLives; //vidas iniciales del jugador

    [Header("Pantalla de GameOver")]
    public GameObject gameOverScreen;//game object de la pantalla de gameover

    public string levelToLoad; //nombre de escena a cargar

    public float waitAfterGameOver; //Tiempo para cargar la escena cuando aparezca la pantalla de gameover

    [Header("Jugador")]
    public PlayerController player; //referencia al jugador

    //variables privadas
    private int livesCounter; //contador de vidas

    public Text livesText; //referencia al componente de texto del objeto
    void MakeSingleton()
    {//start makesingleton
        //checar si hay otra instancia de la referencia
        //checar si la instancia es diferente a nada
        if (instance != null)
        {//start if
            //si existe otra instancia, destruyela
            Destroy(gameObject);
        }//end if
        else
        {//start else
            //esto es si no hay otra instancia
            //la instancia referencia a esta clase
            instance = this;

            //evitar la destruccion de este gameobject al cambiar de escena
           // DontDestroyOnLoad(gameObject);
        }//end else
    }//end makesingleton

    private void Awake()
    {//start awake
        //llamar al metodo singleton
        MakeSingleton();
    }//end awake

    private void Start()
    {//start start
        //inicializar la ref livesText

        //Inicializacion de referencia del jugador
        player = FindObjectOfType<PlayerController>();

        //determinar el valor de contador de vidas
        livesCounter = startingLives;
    }//end start

    private void Update()
    {//start update
        //Condicion para que aparezca la pantalla de gameover
        //la pantalla va a aparecer cuando el jugador muere despues de la vida 0
        if(livesCounter <= 0)
        {//start if
            //activar la pantalla de gameover
            gameOverScreen.SetActive(true);

            //desactivar el go del jugador 
            player.gameObject.SetActive(false);
        }//end if

        //cambiar el contenido del componente de texto
        //aqui vamos a desplegar la x y la cantidad de vidas que tenga el contador 
        livesText.text = "X" + livesCounter;

        //checar si la pantalla de gameover esta activa en escena
        if (gameOverScreen.activeSelf)
        {//start if
            //reducir el tiempo de espera usando el tiempo
            waitAfterGameOver -= Time.deltaTime;
        }//end if

        //evaluar si se termino el tiempo de espera
        if (waitAfterGameOver < 0)
        {//start if
            //cargar la escena escrita en el string
            SceneManager.LoadScene(levelToLoad);
        }//end if
    }//end update

    //metodo para perder vidas
    public void TakeLives()
    {//start takelives
        //disminuir el contador de vidas
        livesCounter--;
    }//end takelives

    public void VidaExtra()
    {
        livesCounter++;
    }

}//end class livemanager
