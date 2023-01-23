using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ER_CamaraFollow : MonoBehaviour
{

    [Header("Objetivo de Cámara")] 
    public Transform target;
    public float distance = 6.5f;
    public float height = 3.5f;

    public float heightDamping = 3.25f;
    public float rotationDamping = 0.27f;




    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float _wantedRotationAngle = target.eulerAngles.y;

        float _wantedHeight = target.position.y + height;

        float _currentRotationAngle = transform.eulerAngles.y;

        float _currentHeight = transform.position.y;

        _currentRotationAngle = Mathf.LerpAngle(_currentRotationAngle,_wantedRotationAngle,rotationDamping * Time.deltaTime);

        _currentHeight = Mathf.Lerp(_currentHeight,_wantedHeight, heightDamping * Time.deltaTime);

        Quaternion _currentRotation = Quaternion.Euler(0f,_currentRotationAngle, 0f);

        transform.position = target.position;

        transform.position -= _currentRotation * Vector3.forward * distance;

        transform.position = new Vector3(transform.position.x, _currentHeight, transform.position.z);

    }

}
