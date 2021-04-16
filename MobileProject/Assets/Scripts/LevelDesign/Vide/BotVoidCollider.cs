using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class BotVoidCollider : MonoBehaviour
{
    public Button botVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool botCollision;
    public bool topCollision;
    public TopVoidCollider topVoidCollider;
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;

    private bool botMove;
    private bool botButtonIsActivable;
    private Vector3 velocity;

    //public Vector3 previousPosition;

    void Start()
    {
        botButtonIsActivable = false;
        botMove = false;
    }

    private void Update()
    {
        if (botMove == true)
        {
            velocity = new Vector3(0.0f, 2.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (botMove == false)
        {
            player.transform.position = player.transform.position;
        }

        topCollision = topVoidCollider.topCollision;

        if (topCollision == true || botButtonIsActivable == false)
        {
            botVoidButton.gameObject.SetActive(false);
        }

        if (botButtonIsActivable == true)
        {
            botVoidButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (topCollision == false)
            {
                if (player == playerManager.currentCharacter)
                {
                    botButtonIsActivable = true;
                }
                else
                {
                    botButtonIsActivable = false;
                }
            }
            else
            {
                botButtonIsActivable = false;
            }
        }
        else
        {
            Debug.Log("4");
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                botCollision = true;
                botButtonIsActivable = false;
            }
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            botButtonIsActivable = false;
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("z");
                botCollision = false;
            }

        }
    }

    public void BotVoidMove()
    {
        StartCoroutine(botClimb());

    }

    IEnumerator botClimb()
    {
        playerMovement.isJumping = true;
        botMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        botMove = false;
        voidCol.enabled = true;
        playerMovement.previousPosition = player.transform.position;
        playerMovement.targetPosition = player.transform.position;
        playerMovement.isJumping = false;
    }
}
