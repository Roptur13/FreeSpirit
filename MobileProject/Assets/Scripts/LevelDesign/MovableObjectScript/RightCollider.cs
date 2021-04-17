using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class RightCollider : MonoBehaviour
{
    public Button rightButton;
    public GameObject mainBody;
    public bool obstacleRight;
    public bool obstacleLeft;
    public LeftCollider leftCollider;
    public PlayerManager playerManager;
    public RepairMovableBlock repairMovable;

    private bool rightMove;
    private Vector3 voidVelocity;

    private List<GameObject> characters;

    void Start()
    {
        rightButton.gameObject.SetActive(false);
        characters = playerManager.characters;
    }

    private void Update()
    {
        if (rightMove == true)
        {
            voidVelocity = new Vector3(-1f, 0f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (rightMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }

        obstacleLeft = leftCollider.obstacleLeft;
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (collision.gameObject == playerManager.currentCharacter)
            {
                if (obstacleLeft == false)
                {
                    rightButton.gameObject.SetActive(true);
                }
                else
                {
                    rightButton.gameObject.SetActive(false);
                }

                if (repairMovable.isBroken == true)
                {
                    if (collision.gameObject == repairMovable.player)
                    {
                        repairMovable.repairButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        repairMovable.repairButton.gameObject.SetActive(false);
                    }
                }
                else
                {
                    repairMovable.repairButton.gameObject.SetActive(false);
                }
            }
            else
            {
                obstacleRight = true;
                rightButton.gameObject.SetActive(false);
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleRight = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;

            if (collision.gameObject == playerManager.currentCharacter)
            {
                rightButton.gameObject.SetActive(false);
            }

            if (repairMovable.isBroken == true)
            {
                if (collision.gameObject == repairMovable.player)
                {
                    repairMovable.repairButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleRight = false;
            }
        }
    }

    public void RightMove()
    {
        StartCoroutine(RightSlide());
    }

    IEnumerator RightSlide()
    {
        rightMove = true;
        yield return new WaitForSeconds(1.0f);
        rightMove = false;
    }
}
