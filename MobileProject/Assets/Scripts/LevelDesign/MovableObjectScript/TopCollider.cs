using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class TopCollider : MonoBehaviour
{
    public Button upButton;
    public GameObject mainBody;
    public bool obstacleTop;
    public bool obstacleBot;
    public BotCollider botCollider;
    public PlayerManager playerManager;
    public RepairMovableBlock repairMovable;

    public TopCollider linkedBlock;

    private bool topMove;
    private Vector3 voidVelocity;

    private List<GameObject> characters;

    void Start()
    {
        upButton.gameObject.SetActive(false);
        characters = playerManager.characters;
    }

    private void Update()
    {
        if (topMove == true)
        {
            voidVelocity = new Vector3(0f, -1f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (topMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }

        obstacleBot = botCollider.obstacleBot;

        
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (characters.Contains(collision.gameObject))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;

            if (collision.gameObject == playerManager.currentCharacter)
            {
                if (obstacleBot == false)
                {
                    upButton.gameObject.SetActive(true);
                }
                else
                {
                    upButton.gameObject.SetActive(false);
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

                    upButton.gameObject.SetActive(false);
                }
                else
                {
                    repairMovable.repairButton.gameObject.SetActive(false);
                    //upButton.gameObject.SetActive(true);
                }
            }
            else
            {
                obstacleTop = true;
                upButton.gameObject.SetActive(false);
            }

        }
        else
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                obstacleTop = true;
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
                upButton.gameObject.SetActive(false);
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
                obstacleTop = false;
            }
        }
    }

    public void TopMove()
    {
        StartCoroutine(TopSlide(this.gameObject.GetComponent<TopCollider>()));
        if (playerManager.sameMovements == true)
        {
            if (linkedBlock.obstacleBot == false)
            {
                StartCoroutine(TopSlide(linkedBlock));
            }
        }
    }

    IEnumerator TopSlide(TopCollider block)
    {
        block.topMove = true;
        yield return new WaitForSeconds(1.0f);
        block.topMove = false;
    }
}
