using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albane & Noé
//Détecte tout les elements

public class PlatformDetectPlayer : MonoBehaviour
{
    public bool playerOnPlatform;
    
    // Start is called before the first frame update
    void Start()
    {
        playerOnPlatform = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerOnPlatform = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnPlatform = false;
    }
}
