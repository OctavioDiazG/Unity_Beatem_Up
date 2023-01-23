using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_GameplayController : MonoBehaviour
{

    #region "Variables"

    public static ER_GameplayController instance;

    [Header("Arreglo de Objetos")]
    public GameObject[] obstaclePrefabs;
    public GameObject[] zombiePrefabs;
    [Header("Carriles de Objetos")]
    public Transform[] lanes;

    [Header("Tiempos para generar obstaculos")]
    public float minObstacleDelay = 10f;
    public float maxObstacleDelay = 40f;

    private float halfGroundSize;

    private ER_BaseController baseController;

    #endregion

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        halfGroundSize = GameObject.Find("GroundBlock Main").GetComponent<ER_GroundBlock>().halfLenght;
        baseController = GameObject.FindGameObjectWithTag("Player").GetComponent<ER_BaseController>();

        StartCoroutine(GenerateObstaclesCo());

    }

    void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if ( instance != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator GenerateObstaclesCo()
    {
        float _timer = Random.Range(minObstacleDelay,maxObstacleDelay) / baseController.speed.z;

        yield return new WaitForSeconds(_timer);

        //Nos quedamos aqui xd

        CreateObstacles(baseController.gameObject.transform.position.z + halfGroundSize);

        StartCoroutine(GenerateObstaclesCo());

    }

    void CreateObstacles(float _zPos)
    {
        int _r = Random.Range(0,10);

        if(0<=_r && _r < 7)
        {
            int _objectLane = Random.Range(0,lanes.Length);

            AddObstacle(new Vector3(lanes[_objectLane].transform.position.x,0f,_zPos),
                        Random.Range(0, obstaclePrefabs.Length));

            int _zombieLane = 0;

            if(_objectLane == 0)
            {
                _zombieLane = Random.Range(0,2) == 1 ? 1 : 2;
            }
            else if(_objectLane == 1)
            {
                _zombieLane = Random.Range(0,2) == 1 ? 0 : 2;
            }
            else if(_objectLane == 2)
            {
                _zombieLane = Random.Range(0,2) == 1 ? 1 : 0;
            }

            AddZombies(new Vector3(lanes[_zombieLane].transform.position.x,0.15f,_zPos));

        }

    }

    void AddObstacle(Vector3 _position, int _type)
    {
        GameObject _obstacle = Instantiate(obstaclePrefabs[_type], _position, Quaternion.identity);
        bool _mirror = Random.Range(0, 2) == 1;

        switch (_type)
        {
            case 0:
                _obstacle.transform.rotation = Quaternion.Euler(0f, _mirror ? -20 : 20, 0f);
                break;
            case 1:
                _obstacle.transform.rotation = Quaternion.Euler(0f, _mirror ? 20 : -20, 0f);
                break;
            case 2:
                _obstacle.transform.rotation = Quaternion.Euler(0f, _mirror ? -10 : 10, 0f);
                break;
            case 3:
                _obstacle.transform.rotation = Quaternion.Euler(0f, _mirror ? -170 : 170, 0f);
                break;
            default:
                _obstacle.transform.rotation = Quaternion.Euler(0f, _mirror ? 170 : -170, 0f);
                break;
        }

        _obstacle.transform.position = _position;
    }

    void AddZombies(Vector3 _position)
    {
        int _count = Random.Range(0,3) + 1;

        for(int i = 0; i <_count; i++)
        {
            Vector3 _shift = new Vector3(Random.Range(-0.5f,0.5f),0f,Random.Range(1f,10f)* i);

            Instantiate(zombiePrefabs[Random.Range(0,zombiePrefabs.Length)],
                        _position + _shift * i,
                        Quaternion.identity);

        }

    }



}
