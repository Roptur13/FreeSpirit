using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerManager : MonoBehaviour
{

    public List <GameObject> characters = new List<GameObject>();

    public GameObject currentCharacter;

    public bool sameMovements;

    void Start()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (sameMovements == false)
            {
                characters[i].GetComponent<PlayerMovement>().enabled = false;
            }            
        }

        currentCharacter = characters[0];
    }

    public void ChangeCharacter(GameObject player)
    {
        if (sameMovements == false)
        {
            currentCharacter.GetComponent<PlayerMovement>().enabled = false;
        }
        currentCharacter = player;
        
    }
}
