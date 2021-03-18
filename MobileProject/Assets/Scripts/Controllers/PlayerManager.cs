using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//Script de Noé

public class PlayerManager : MonoBehaviour
{

    public GameObject[] characters;

    public GameObject currentCharacter;

    void Start()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].GetComponent<AIPath>().enabled = false;
        }

        currentCharacter = characters[0];
    }

    public void ChangeCharacter(GameObject player)
    {
        currentCharacter.GetComponent<AIPath>().enabled = false;
        currentCharacter = player;
    }
}
