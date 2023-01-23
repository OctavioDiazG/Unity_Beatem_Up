using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BEU_HealtUi : MonoBehaviour
{

    public Image saludUI;
    // Start is called before the first frame update
    public void DisplayHealth(float valor, float max)
    {
        valor /= max;

        if (valor < 0f)
        {
            valor = 0f;
        }

        saludUI.fillAmount = valor;
    }
}
