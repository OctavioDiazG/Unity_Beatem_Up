using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscena : MonoBehaviour
{
    public GameObject objeto;
    public GameObject objeto2;
    public void change(string next)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(next);
    }

    public void activador(bool a)
    {
      objeto.SetActive(a);

      a = !a;
      
      objeto2.SetActive(a);
    }
}
