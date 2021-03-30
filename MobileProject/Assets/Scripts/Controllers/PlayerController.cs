using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerController : MonoBehaviour
{
    public enum characterColor { Red, Blue, Yellow};
    public characterColor color;

    public PlayerManager playerManager;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        playerManager.ChangeCharacter(this.gameObject);
        GetComponent<PlayerMovement>().enabled = true;
    }
}
