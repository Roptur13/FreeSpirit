using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwitch : MonoBehaviour
{
    public DoubleSwitch linkedSwitch;

    public bool isActivated;

    public GameObject objectToActive;

    private bool finish;

    private SpriteRenderer spriteRender;

    public Sprite onSprite;
    public Sprite offSprite;

    void Start()
    {
        isActivated = false;

        finish = false;

        spriteRender = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (isActivated == true && linkedSwitch.isActivated == true)
        {
            objectToActive.SetActive(false);
            finish = true;
        }

        if (finish == false && isActivated == false)
        {
            spriteRender.material.color = Color.red;
            //spriteRender.sprite = offSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isActivated = true;
            spriteRender.material.color = Color.green;
            //spriteRender.sprite = onSprite;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isActivated = false;
        }        
        
    }
}
