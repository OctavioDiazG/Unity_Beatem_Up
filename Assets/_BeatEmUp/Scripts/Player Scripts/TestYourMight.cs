using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TestYourMight : MonoBehaviour
{
    [SerializeField]private float mashDelay;
    private float mash;
    private bool started = true;
    [SerializeField]private float tiempo; 
    public Image barraUI;
    public GameObject barra;


    // Start is called before the first frame update
    void Start()
    {
        mash = mashDelay;
    }

    // Update is called once per frame
    void Update()
    {

        mash -= Time.deltaTime;

        if (started)
        {
            barra.SetActive(true);
            tiempo -= Time.deltaTime;
            probador();
        }
    }

    private void probador()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            barraUI.fillAmount += 0.05f;
        }

        if (mash <= 0)
        {
            mash = mashDelay;
            barraUI.fillAmount -= 0.01f;
        }

        if (barraUI.fillAmount >= 0.99f)
        {
            started = false;
            Debug.Log("ganaste"); 
            barra.SetActive(false);
        }

        if (tiempo <= 0)
        {
            started = false;
            Debug.Log("cagaste");
            barra.SetActive(false);
        }
    }
}