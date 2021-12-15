using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alumno : MonoBehaviour
{
    public GameObject titulo;
    public GameObject entrar;
    public GameObject alumno;
    public GameObject faltar;
    public GameObject alumnoQuote;
    public GameObject back;
    public AudioSource sonidoBoton;
    public AudioSource sonidoBotonInverted;

    public void AlumnoFuncion()
    {
        sonidoBoton.Play();
        titulo.SetActive(false);
        entrar.SetActive(false);
        alumno.SetActive(false);
        faltar.SetActive(false);

        alumnoQuote.SetActive(true);
        back.SetActive(true);
    }

    public void VolverFuncion()
    {
        sonidoBotonInverted.Play();
        titulo.SetActive(true);
        entrar.SetActive(true);
        alumno.SetActive(true);
        faltar.SetActive(true);

        alumnoQuote.SetActive(false);
        back.SetActive(false);
    }
}
