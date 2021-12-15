using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject cargando;
    public AudioSource sonidoBoton;

    [HideInInspector]
    public bool cargo = false;

    public void Gameplay()
    {
        sonidoBoton.Play();
        StartCoroutine(GameplayStart());
    }

    IEnumerator GameplayStart()
    {
        fadeOut.SetActive(true);
        cargando.SetActive(true);
        yield return new WaitForSeconds(3);
        cargo = true;
        haCargado();
    }

    public void haCargado()
    { 
        if(cargo==true)
        SceneManager.LoadScene(1);
    }
    public void QuitApp()
    {
        sonidoBoton.Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
