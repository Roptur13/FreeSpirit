using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class TargetScript : MonoBehaviour
{

    [SerializeField]
    //private bool isActive;

    Vector3 wantedPosition;
    
    void Start()
    {
        //isActive = false;

        ChangeTargetPosition();
    }

    
    void Update()
    {
        ChangeTargetPosition();
    }

    void ChangeTargetPosition()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //isActive = true;
            Vector3 clickPosition = Input.mousePosition;

            clickPosition.z = clickPosition.z - (Camera.main.transform.position.z);

            wantedPosition = Camera.main.ScreenToWorldPoint(clickPosition);            

            transform.position = wantedPosition;

            
        }
    }
}
