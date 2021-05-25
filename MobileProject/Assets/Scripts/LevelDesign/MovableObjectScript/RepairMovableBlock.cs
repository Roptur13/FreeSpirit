using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Noé

public class RepairMovableBlock : MonoBehaviour
{
    public Button repairButton;

    public Sprite brokenSprite;
    public Sprite fixedSprite;

    public Collider2D topTrigger;
    public Collider2D bottomTrigger;
    public Collider2D leftTrigger;
    public Collider2D rightTrigger;

    public bool isBroken;

    public GameObject movableBlock;
    private SpriteRenderer spriteRenderer;

    public GameObject player;

    private BoxCollider2D movableBlockCollider;

    public RepairMovableBlock linkedBlock;


    void Start()
    {
        repairButton.gameObject.SetActive(false);
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        movableBlockCollider = GetComponentInParent<BoxCollider2D>();
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

            movableBlockCollider.enabled = false;
        }
    }    

    public void RepairBlock()
    {        
        spriteRenderer.sprite = fixedSprite;

        topTrigger.enabled = true;
        bottomTrigger.enabled = true;
        leftTrigger.enabled = true;
        rightTrigger.enabled = true;

        isBroken = false;

        movableBlockCollider.enabled = true;

        if (linkedBlock != null)
        {
            repairButton.gameObject.SetActive(false);
        }
        else
        {
            return;
        }

        linkedBlock.RepairBlock();
    }
}
