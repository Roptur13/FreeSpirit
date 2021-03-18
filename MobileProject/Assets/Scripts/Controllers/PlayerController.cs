using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

//Script de Noé

public class PlayerController : MonoBehaviour
{
    public enum characterColor { Red, Blue, Yellow, Purple, Orange, Green };
    public characterColor color;

    public PlayerManager playerManager;

    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        playerManager.ChangeCharacter(this.gameObject);
        GetComponent<AIPath>().enabled = true;
    }
}
