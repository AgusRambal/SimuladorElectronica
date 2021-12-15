using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambioDeObjetivo : MonoBehaviour
{
    public GameObject texto;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            texto.GetComponent<TextMeshProUGUI>().text = "La frecuencia de salida debe ser de 1Hz "; ;
    }
}
