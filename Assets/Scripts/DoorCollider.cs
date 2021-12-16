using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollider : MonoBehaviour
{
    public GameObject fadeOutFinal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fadeOutFinal.SetActive(true);
            StartCoroutine(TroughScene());
        }
    }

    IEnumerator TroughScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
