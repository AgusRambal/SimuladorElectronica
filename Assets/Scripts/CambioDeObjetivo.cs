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
            texto.GetComponent<TextMeshProUGUI>().text = "El tiempo del 555 debe ser de 1.3 mS"; ;
            StartCoroutine(MostrarAyuda());
        }
    }

    IEnumerator MostrarAyuda()
    {
        yield return new WaitForSeconds(5f);
        ayuda.SetActive(true);
    }
}
