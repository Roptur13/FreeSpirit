using System.Collections;

using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class LeftVoidCollider : MonoBehaviour
{
    public Button leftVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool rightCollision;
    public bool leftCollision;
    public RightVoidCollider rightVoidCollider;
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;

    private bool leftMove;
    private bool leftButtonIsActivable;
    private Vector3 velocity;

    //private Vector3 previousPosition; 

    void Start()
    {
        leftButtonIsActivable = false;
        leftMove = false;
    }

    private void Update()
    {
        if (leftMove == true)
        {
            velocity = new Vector3(2.0f, 0.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        /*else if (leftMove == false)
        {
            player.transform.position = player.transform.position;
        }*/

        rightCollision = rightVoidCollider.rightCollision;

        if (rightCollision == true || leftButtonIsActivable == false)
        {
            leftVoidButton.gameObject.SetActive(false);
        }

        if (leftButtonIsActivable == true)
        {
            leftVoidButton.gameObject.SetActive(true);
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (rightCollision == false)
            {
                if (player == playerManager.currentCharacter)
                {
                    leftButtonIsActivable = true;
                }
                else
                {
                    leftButtonIsActivable = false;
                }

            }
            else
            {
                leftButtonIsActivable = false;
            }
            
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                leftCollision = true;

                leftButtonIsActivable = false;
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            leftButtonIsActivable = false;
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                leftCollision = false;
            }
            
        }
    }

    public void LeftVoidMove()
    {
        StartCoroutine(leftGlide());
    }

    IEnumerator leftGlide()
    {
        playerMovement.isJumping = true;
        leftMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        leftMove = false;
        voidCol.enabled = true;
        playerMovement.previousPosition = player.transform.position;
        playerMovement.targetPosition = player.transform.position;
        playerMovement.isJumping = false;
    }
}
