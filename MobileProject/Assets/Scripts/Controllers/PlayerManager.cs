using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerManager : MonoBehaviour
{

    public List <GameObject> characters = new List<GameObject>();

    public GameObject currentCharacter;

    void Start()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].GetComponent<PlayerMovement>().enabled = false;
        }

        currentCharacter = characters[0];
    }

    public void ChangeCharacter(GameObject player)
    {
        currentCharacter.GetComponent<PlayerMovement>().enabled = false;
        currentCharacter = player;
        
    }
}
