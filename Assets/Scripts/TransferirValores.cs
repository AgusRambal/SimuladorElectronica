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
    public GameObject Resultado;
    public GameObject textoGanaste;

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

        Resultado.SetActive(true);

        if (1.3 <= valorLuz && valorLuz <= 1.4) 
        {
            ganaste = true;
            Resultado.GetComponent<TextMeshProUGUI>().text = "T = " + valorLuz + ", Muy bien! Ese el tiempo pedido";
            textoGanaste.SetActive(true);
        }
        else
        {
            textoErroneo.SetActive(true);
            Resultado.GetComponent<TextMeshProUGUI>().text = "El tiempo con dicha R es de: " + valorLuz + " mS";
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

            if (valor=="0")
            {
                luz.enabled = false;
                Resultado.GetComponent<TextMeshProUGUI>().text = "No se puede poner la R en 0!!";
            }
        }
    }
}
