using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potenciometro : MonoBehaviour
{
    public GameObject texto;
    public GameObject campoTexto;
    public GameObject boton;

    public float toque;//1

    public void TocarPotenciometro(float amount)
    {
        toque -= amount;

        if (toque <=0)
        {
            LoToque();
        }
    }

    void LoToque()
    {
        Cursor.lockState = CursorLockMode.None;
        campoTexto.SetActive(true);
        boton.SetActive(true);
    }
}
