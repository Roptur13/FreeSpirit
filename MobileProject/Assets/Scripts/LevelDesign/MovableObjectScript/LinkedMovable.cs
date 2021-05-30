
using UnityEngine;

// Script de Noé

public class LinkedMovable : MonoBehaviour
{
    public RepairMovableBlock linkedBlock;
    public Sprite brokenSprite;
    public Sprite fixedSprite;

    public Collider2D topTrigger;
    public Collider2D bottomTrigger;
    public Collider2D leftTrigger;
    public Collider2D rightTrigger;

    public bool isBroken;

    private SpriteRenderer spriteRenderer;
    public GameObject movableBlock;

    private BoxCollider2D movableBlockCollider;

    void Start()
    {
        spriteRenderer = movableBlock.GetComponent<SpriteRenderer>();
        movableBlockCollider = GetComponentInParent<BoxCollider2D>();
    }

    
    void Update()
    {
        if (isBroken == true)
        {
            topTrigger.enabled = false;
            bottomTrigger.enabled = false;
            leftTrigger.enabled = false;
            rightTrigger.enabled = false;

            spriteRenderer.sprite = brokenSprite;

            movableBlockCollider.enabled = false;
        }

        if(linkedBlock.isBroken == false)
        {
            RepairLinkedMovable();
        }
    }

    void RepairLinkedMovable()
    {
        isBroken = false;

        spriteRenderer.sprite = fixedSprite;

        topTrigger.enabled = true;
        bottomTrigger.enabled = true;
        leftTrigger.enabled = true;
        rightTrigger.enabled = true;

        isBroken = false;

        movableBlockCollider.enabled = true;
    }
}
