using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//script de Samuel
public class TopVoidCollider : MonoBehaviour
{
    public Button topVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool botCollision;
    public bool topCollision;
    public BotVoidCollider botVoidCollider;
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;

    private bool topMove;
    private bool topButtonIsActivable;
    private Vector3 velocity;

    //public Vector3 previousPosition;

    void Start()
    {
        topButtonIsActivable = false;
        topMove = false;
    }

    private void Update()
    {
        if (topMove == true)
        {
            velocity = new Vector3(0.0f, -2.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (topMove == false)
        {
            player.transform.position = player.transform.position;
        }

        botCollision = botVoidCollider.botCollision;

        if (botCollision == true || topButtonIsActivable == false)
        {
            topVoidButton.gameObject.SetActive(false);
        }

        if (topButtonIsActivable == true)
        {
            topVoidButton.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (botCollision == false)
            {
                if (player == playerManager.currentCharacter)
                {
                    topButtonIsActivable = true;
                }
                else
                {
                    topButtonIsActivable = false;
                }
            }
            else
            {
                topButtonIsActivable = false;
                Debug.Log("objet bloquant en bas");
            }
           
        }
        else
        {
            Debug.Log("3");
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                topCollision = true;

                topButtonIsActivable = false;
                Debug.Log(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            topButtonIsActivable = false;
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                
                topCollision = false;
            }

        }
    }

    public void TopVoidMove()
    {
        StartCoroutine(topFall());
    }

     IEnumerator topFall()
    {
        playerMovement.isJumping = true;
        topMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        topMove = false;
        voidCol.enabled = true;
        playerMovement.previousPosition = player.transform.position;
        playerMovement.targetPosition = player.transform.position;
        playerMovement.isJumping = false;
    }
    
}
