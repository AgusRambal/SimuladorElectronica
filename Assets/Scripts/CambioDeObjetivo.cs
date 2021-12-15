using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CambioDeObjetivo : MonoBehaviour
{
    public GameObject texto;

    public GameObject ayuda;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        { 
            texto.GetComponent<TextMeshProUGUI>().text = "La frecuencia de salida debe ser de 1Hz "; ;
            StartCoroutine(MostrarAyuda());
        }
    }

    IEnumerator MostrarAyuda()
    {
        yield return new WaitForSeconds(5f);
        ayuda.SetActive(true);
    }
}
