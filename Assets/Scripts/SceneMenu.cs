using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    public GameObject fadeIn;
    public AudioSource sonidoBoton;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Menu()
    {
        sonidoBoton.Play();
        SceneManager.LoadScene(0);
    }
}
