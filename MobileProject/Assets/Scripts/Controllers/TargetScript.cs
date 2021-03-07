using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class TargetScript : MonoBehaviour
{

    [SerializeField]
    private bool isActive;

    private Vector3 targetWantedPosition;
    
    void Start()
    {
        isActive = false;
    }

    
    void Update()
    {
        ChangeTargetPosition(targetWantedPosition);
    }

    void ChangeTargetPosition(Vector3 newPosition)
    {
        if(Input.GetButtonDown("Fire1"))
        {
            isActive = true;

            newPosition = Input.mousePosition;

            transform.position = newPosition;
        }
    }
}
