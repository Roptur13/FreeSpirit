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
        
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (player == playerManager.currentCharacter)
            {
                RepairButton.gameObject.SetActive(true);
                Debug.Log("trux");
            }
            else
            {
                RepairButton.gameObject.SetActive(false);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            RepairButton.gameObject.SetActive(false);
            Debug.Log("bouton viré");

            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;

        }        
    }
}
