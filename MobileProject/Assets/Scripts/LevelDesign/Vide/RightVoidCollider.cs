using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class RightVoidCollider : MonoBehaviour
{
    public Button rightVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool rightCollision;
    public bool leftCollision;
    public LeftVoidCollider leftVoidCollider;
    public PlayerManager playerManager;
    public PlayerMovement playerMovement;

    private bool rightMove;
    private bool rightButtonIsActivable;
    private Vector3 velocity;

    //public Vector3 previousPosition;

    void Start()
    {
        rightButtonIsActivable = false;
        rightMove = false;
    }

    private void Update()
    {
        if (rightMove == true)
        {
            velocity = new Vector3(-2.0f, 0.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (rightMove == false)
        {
            player.transform.position = player.transform.position;
        }

        leftCollision = leftVoidCollider.leftCollision;

        if (leftCollision == true || rightButtonIsActivable == false)
        {
            rightVoidButton.gameObject.SetActive(false);
        }

        if (rightButtonIsActivable == true)
        {
            rightVoidButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (leftCollision == false)
            {
                if (player == playerManager.currentCharacter)
                {
                    rightButtonIsActivable = true;
                }
                else
                {
                    rightButtonIsActivable = false;
                }
                
            }
            else
            {
                rightButtonIsActivable = false;
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                rightCollision = true;

                rightButtonIsActivable = false;
            }            
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            rightButtonIsActivable = false;
            player.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                rightCollision = false;
            }
            
        }        
        
    }

    public void RightVoidMove()
    {
        StartCoroutine(rightGlide());
    }

    IEnumerator rightGlide()
    {
        playerMovement.isJumping = true;
        rightMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        rightMove = false;
        voidCol.enabled = true;
        playerMovement.previousPosition = player.transform.position;
        playerMovement.targetPosition = player.transform.position;
        playerMovement.isJumping = false;
    }
}
