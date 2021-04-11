using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerController : MonoBehaviour
{
    public PlayerManager playerManager;

    public bool blue;
    public bool red;
    public bool yellow;


    private void OnMouseDown()
    {
        playerManager.ChangeCharacter(this.gameObject);
        GetComponent<PlayerMovement>().enabled = true;
    }
}
