using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class LeftCollider : MonoBehaviour
{
    public Button leftButton;
    public GameObject mainBody;
    public bool obstacleLeft;
    public bool obstacleRight;
    public RightCollider rightCollider;
    public PlayerManager playerManager;
    public RepairMovableBlock repairMovable;

    public LeftCollider linkedBlock;

    private bool leftMove;
    private Vector3 voidVelocity;

    private List<GameObject> characters;

    void Start()
    {
        leftButton.gameObject.SetActive(false);
        characters = playerManager.characters;
    }

    private void Update()
    {
        if (leftMove == true)
        {
            voidVelocity = new Vector3(1f, 0f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (leftMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }

        obstacleRight = rightCollider.obstacleRight;
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (collision.gameObject == playerManager.currentCharacter)
            {
                if (obstacleRight == false)
                {
                    leftButton.gameObject.SetActive(true);
                }
                else
                {
                    leftButton.gameObject.SetActive(false);
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

                    leftButton.gameObject.SetActive(false);
                }
                else
                {
                    repairMovable.repairButton.gameObject.SetActive(false);
                    leftButton.gameObject.SetActive(true);
                }
            }
            else
            {
                obstacleLeft = true;
                leftButton.gameObject.SetActive(false);
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleLeft = true;
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
                leftButton.gameObject.SetActive(false);
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
                obstacleLeft = false;
            }
        }
    }

    public void LeftMove()
    {
        StartCoroutine(LeftSlide(this.gameObject.GetComponent<LeftCollider>()));
        if (playerManager.sameMovements == true)
        {
            if (linkedBlock.obstacleRight == false)
            {
                StartCoroutine(LeftSlide(linkedBlock));
            }
        }
    }

    IEnumerator LeftSlide(LeftCollider block)
    {
        block.leftMove = true;
        yield return new WaitForSeconds(1.0f);
        block.leftMove = false;
    }
}
