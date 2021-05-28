using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerManager : MonoBehaviour
{

    public List <GameObject> characters = new List<GameObject>();

    public GameObject currentCharacter;

    public bool sameMovements;
    public bool menuIsActive;

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
        menuIsActive = false;
    }

    public void ChangeCharacter(GameObject player)
    {
        if (sameMovements == false)
        {
            currentCharacter.GetComponent<PlayerMovement>().enabled = false;
        }
        currentCharacter = player;
        
    }

    public void StopCharacter(PlayerManager playerManager)
    {
        bool canMove = playerManager.currentCharacter.GetComponent<PlayerMovement>().canMove;
        if (menuIsActive == false)
        {
            menuIsActive = true;
        }
        else
        {
            menuIsActive = false;
            Debug.Log("machin");
        }
        


        if (canMove == true)
        {
            canMove = false;            
        }
        if (canMove == false)
        {
            canMove = true;            
        }
    }
}
