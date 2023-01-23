using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{//start el class de level manager
    //empezar a escribor mas comentarios

    //variables publicas 
    public static LevelManager instance; //referencia de esta clase

    [Header("Puntos Restados Cuando mueres")]
    public int pointPenaltyOnDeath = 200;

    [Header("Punto de Reaparicion")]
    public GameObject respawnPoint; //el gameobject en donde reaparece el profe

    [Header("Particulas")]
    public GameObject deathParticles; //el gameobject de cuando muere el jugador
    public GameObject respawnParticles; //el gameobkect de las particulas de reaparicion del jugador

    [Header("Tiempo de Reaparacion de Jugador")]
    public float respawnTimer = 1f; //tiempo de reaparacion del jugador para revivir

    //Variables privadas
    private PlayerController player; //referencia del script de player

    private void Awake()
    {//start awake
        //llamar al metodo singleton
        MakeSingleton();
    }//end awake

    private void Start()
    {//inicio del start
        //inicializar el player reference
        player = FindObjectOfType<PlayerController>();
    }//end de start 

    //metodo para crear singleton
    void MakeSingleton()
    {//start makesingleton
        //checar si hay otra instancia de la referencia
        //checar si la instancia es diferente a nada
        if(instance != null)
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
            //DontDestroyOnLoad(gameObject);
        }//end else
    }//end makesingleton

    //funciones publicas:
    //funcion de reparacion del jugador
    public void RespawnPlayer()
    {//start respawnplayer
        //llamar a la corrutina de reparacion
        StartCoroutine(RespawnPlayerCo());
    }//end respawnplayer
    
    //corrutina de reaparicion del player
    public IEnumerator RespawnPlayerCo()
    {//start de la corrutina
        //instanciar las particulas de muerte
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);

        //desactivar la funcionalidad del jugador
        player.enabled = false;
        //desactivar la visibilidad del jugador
        player.GetComponent<Renderer>().enabled = false;
        //desactuvar el collider del jugador
        player.GetComponent<Collider2D>().enabled = false;

        //usar el scoremanager para restar puntos
        ScoreManager.AddPoints(-pointPenaltyOnDeath);

        //vamos a llamar al metodo takelives de livesmanager
        LivesManager.instance.TakeLives();

        //mensaje en consola de reaparicion de jugador
        Debug.Log("PLAYER RESPAWNED");

        //cumplir con corrutina. pausa para reaparicion
        yield return new WaitForSeconds(respawnTimer);

        //mover al jugador a la posicion de respawn point
        player.transform.position = respawnPoint.transform.position;
        
        //activar la funcionalidad del jugador
        player.enabled = true;
        //activar la visibilidad del jugador
        player.GetComponent<Renderer>().enabled = true;
        //activar el collider del jugador
        player.GetComponent<Collider2D>().enabled = true;

        //instancear las particulas de respawn del player
        Instantiate(respawnParticles, respawnPoint.transform.position, respawnPoint.transform.rotation);
    }//end de la corrutina

}//end el class de level manager B)
