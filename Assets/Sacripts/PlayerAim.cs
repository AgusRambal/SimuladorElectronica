using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Camera fpsCam;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastFunction();
        }

    }

    void RaycastFunction()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        { 
            Debug.Log(hit.transform.name);
        }
    }
}
