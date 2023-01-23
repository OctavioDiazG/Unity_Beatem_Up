using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
   public void cambiazo()
   {
      SceneManager.LoadScene("SpaceGame");
   }
}
