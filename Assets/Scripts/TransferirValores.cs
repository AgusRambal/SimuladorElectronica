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
    public float valorLuz; //ESTE ES EL PARAMETRO PARA EL LED, OSEA EL POTENCIOMETRO
    public float timer = 10;
    public bool ganaste = false;

    private void Update()
    {
        Led();
    }

    public void LeerElFuckingNumero(string s)
    {
        sonidoBoton.Play();
        valor = s;

        if (valor == "1000")
        {
            valorLuz = 1.750f;
            ganaste = true;
        }

        else if (valor == "10000")
        {
            valorLuz = 3f;
            textoErroneo.SetActive(true);
        }

        else if (valor == "100000")
        {
            valorLuz = 5.5f;
            textoErroneo.SetActive(true);
        }

        else if (valor != "1000" || valor != "10000" || valor != "100000")
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

    //// CUANDO EL OBJETIVO SE CUMPLA CAMBIAR DE NIVEL O ALGUNA OTRA COSA
    //// SI EL VALOR ESTA ERRONEO, TIRAR ALGUN MENSAJE DE ESTA MAL
}
