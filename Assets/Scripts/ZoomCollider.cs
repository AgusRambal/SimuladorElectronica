using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCollider : MonoBehaviour
{
    public GameObject comoJugar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            StartCoroutine(ComoSeJuega());
    }

    IEnumerator ComoSeJuega()
    {
        comoJugar.SetActive(true);
        yield return new WaitForSeconds(3f);
        comoJugar.SetActive(false);
        Destroy(gameObject);
    }
}
