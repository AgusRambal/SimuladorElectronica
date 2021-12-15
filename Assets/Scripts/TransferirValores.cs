using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransferirValores : MonoBehaviour
{
    [Header("Entradas de texto")]
    private string valor;
    public GameObject texto;
    public GameObject campoTexto;
    public GameObject boton;
    public GameObject textoErroneo;
    public AudioSource sonidoBoton;

    [Header("Led Parpadeante")]
    public Light luz;
    public float valorLuz;
    public float timer = 10;
    public bool ganaste = false;
    public bool perdiste = false;

    private void Update()
    {
        Led();
    }

    public void LeerElFuckingNumero(string s)
    {
        sonidoBoton.Play();
        valor = s;

        if (valor == "0")
        {
            perdiste = true;
            //ACA PERDES
        }

        valorLuz = 0.693f * (22000f + int.Parse(valor)) * 0.000047f;
        Debug.Log(valorLuz);

        if (1.3 <= valorLuz && valorLuz <= 1.4) 
        {
            ganaste = true;
            //ACA GANAS
        }
        else
        {
            textoErroneo.SetActive(true);
        }

        StartCoroutine(LeErraste());
        Cursor.lockState = CursorLockMode.Locked;
        campoTexto.SetActive(false);
        boton.SetActive(false);
    }

    IEnumerator LeErraste()
    {
        yield return new WaitForSeconds(2);
        textoErroneo.SetActive(false);
    }

    public void Led()
    {
        if (timer > 0)
            timer -= Time.deltaTime *10;
        if (timer <= 0)
        {
            luz.enabled = !luz.enabled;
            timer = valorLuz;
        }
    }
}
