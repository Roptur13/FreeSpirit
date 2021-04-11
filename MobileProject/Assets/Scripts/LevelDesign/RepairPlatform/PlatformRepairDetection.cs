using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlatformRepairDetection : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject player;
    public Button RepairButton;
    private PlayerController playerController;
    
    void Start()
    {        
        RepairButton.gameObject.SetActive(false);
    }

    void Update()
    {
        player = playerManager.currentCharacter;
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueChara"))
        {
            RepairButton.gameObject.SetActive(true);
            Debug.Log("trux");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RepairButton.gameObject.SetActive(false);
    }
}
