using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransferirValores : MonoBehaviour
{
    [Header("Entradas de texto")]
    private string valor;
    public GameObject inputField;
    public GameObject texto;
    public GameObject campoTexto;
    public GameObject boton;
    public AudioSource sonidoBoton;

    [Header("Led Parpadeante")]
    public Light luz;
    public float valorLuz = 10; //ESTE ES EL PARAMETRO PARA EL LED, OSEA EL POTENCIOMETRO
    public float timer = 10;

    private void Update()
    {
        Led();
    }

    public void GuardarValor()
    {
        sonidoBoton.Play();
        valor = inputField.GetComponent<TextMeshProUGUI>().text;
        
        texto.GetComponent<TextMeshProUGUI>().text = "El valor elegido fue " + valor + " ohm"; //Comentar esto despues

        if (valor == 470.ToString())
        {
            Debug.Log("FUNCIONAAAA"); //ACA TENGO QUE PONER VALOZ LUZ
        }

        Cursor.lockState = CursorLockMode.Locked;
        campoTexto.SetActive(false);
        boton.SetActive(false);
    }

    public void Led()
    {
        if (timer > 0)
            timer -= Time.deltaTime *5;
        if (timer <= 0)
        {
            luz.enabled = !luz.enabled;
            timer = valorLuz;
        }
    }

    //// CUANDO EL OBJETIVO SE CUMPLA CAMBIAR DE NIVEL O ALGUNA OTRA COSA
    //// SI EL VALOR ESTA ERRONEO, TIRAR ALGUN MENSAJE DE ESTA MAL
}
