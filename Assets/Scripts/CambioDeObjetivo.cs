using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static TransferirValores;

public class CambioDeObjetivo : MonoBehaviour
{
    public TransferirValores transferir;
    public GameObject texto;
    public GameObject ayuda;

    private void Update()
    {
        if (transferir.ganaste == true)
        {
           texto.GetComponent<TextMeshProUGUI>().text = "Anda a la puerta para ir a clases";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        { 
            texto.GetComponent<TextMeshProUGUI>().text = "El tiempo del 555 debe ser de 1.3 mS";
            StartCoroutine(MostrarAyuda());
        }
    }

    IEnumerator MostrarAyuda()
    {
        yield return new WaitForSeconds(5f);
        ayuda.SetActive(true);
    }
}
