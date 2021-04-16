using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class BotCollider : MonoBehaviour
{
    public Button botButton;
    public GameObject mainBody;
    public bool obstacleBot;
    public bool obstacleTop;
    public TopCollider topCollider;
    public PlayerManager playerManager;

    private bool botMove;
    private Vector3 voidVelocity;

    void Start()
    {
        botButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (botMove == true)
        {
            voidVelocity = new Vector3(0f, 1f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (botMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }

        obstacleTop = topCollider.obstacleTop;
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == playerManager.currentCharacter)
        {
            if (obstacleTop == false)
            {
                botButton.gameObject.SetActive(true);
            }
            else
            {
                botButton.gameObject.SetActive(false);
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleBot = true;
            }            
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == playerManager.currentCharacter)
        {
            botButton.gameObject.SetActive(false);
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleBot = false;
            }
        }        
        
    }

    public void BotMove()
    {
        StartCoroutine(BotSlide());
    }

    IEnumerator BotSlide()
    {
        botMove = true;
        yield return new WaitForSeconds(1.0f);
        botMove = false;
    }
}
