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
    public RepairMovableBlock repairMovable;

    public BotCollider linkedBlock;

    private bool botMove;
    private Vector3 voidVelocity;
    private List<GameObject> characters;

    void Start()
    {
        botButton.gameObject.SetActive(false);
        characters = playerManager.characters;
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
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

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
                obstacleBot = true;
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
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;

            if (collision.gameObject == playerManager.currentCharacter)
            {
                botButton.gameObject.SetActive(false);
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
                obstacleBot = false;
            }
        }

    }

    public void BotMove()
    {
        StartCoroutine(BotSlide(this.gameObject.GetComponent<BotCollider>()));
        if (playerManager.sameMovements == true)
        {
            if (linkedBlock.obstacleTop == false)
            {
                StartCoroutine(BotSlide(linkedBlock));
            }
        }
    }

    IEnumerator BotSlide(BotCollider block)
    {
        block.botMove = true;
        yield return new WaitForSeconds(1.0f);
        block.botMove = false;
    }
}
