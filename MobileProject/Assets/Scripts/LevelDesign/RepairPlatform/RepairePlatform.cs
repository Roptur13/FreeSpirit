using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Noé

public class RepairePlatform : MonoBehaviour
{
    public Button repairButton;

    public Sprite brokenSprite;
    public Sprite fixedSprite;

    public Collider2D topTrigger;
    public Collider2D bottomTrigger;
    public Collider2D leftTrigger;
    public Collider2D rightTrigger;

    public bool isBroken;

    public GameObject Platform;
    private SpriteRenderer spriteRenderer;

    public GameObject player;
    private PlayerController playerController;

    
    public GameObject SwipeManager;
    public int swipeCount;
    private int currentSwipeCount;

    public int swipeBeforeDestroy = 2;

    
    public GameObject playerDetect;
    public bool playerOnPlatform;


    void Start()
    {
        repairButton.gameObject.SetActive(false);
        spriteRenderer = Platform.GetComponent<SpriteRenderer>();
        playerController = player.GetComponent<PlayerController>();
    }


    void Update()
    {
        if (isBroken == true)
        {
            //topTrigger.enabled = false;
            //bottomTrigger.enabled = false;
            //leftTrigger.enabled = false;
            //rightTrigger.enabled = false;

            spriteRenderer.sprite = brokenSprite;
        }

        swipeCount = SwipeManager.GetComponent<SwipeScript >().swipeCount;
        playerOnPlatform = playerDetect.GetComponent<PlatformDetectPlayer >().playerOnPlatform;

        if (swipeCount - currentSwipeCount >= swipeBeforeDestroy && playerOnPlatform == false)
        {
            DestroyBlock();
        }
        
    }

    public void RepairBlock()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        spriteRenderer.sprite = fixedSprite;

        topTrigger.enabled = false;
        bottomTrigger.enabled = false;
        leftTrigger.enabled = false;
        rightTrigger.enabled = false;

        isBroken = false;

        currentSwipeCount = swipeCount;
    }

    public void DestroyBlock()
    {
        GetComponent<BoxCollider2D>().enabled = true;

        spriteRenderer.sprite = brokenSprite;

        topTrigger.enabled = true;
        bottomTrigger.enabled = true;
        leftTrigger.enabled = true;
        rightTrigger.enabled = true;

        isBroken = true;
    }

}
