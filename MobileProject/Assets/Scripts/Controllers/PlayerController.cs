using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Script de Noé

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navAgent;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            navAgent.destination = Input.mousePosition;
        }
    }
}
