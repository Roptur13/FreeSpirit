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

    private bool botMove;
    private Vector3 velocity;

    //public Vector3 previousPosition;

    void Start()
    {
        botVoidButton.gameObject.SetActive(false);
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
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") && topCollision == false)
        {
            botVoidButton.gameObject.SetActive(true);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("YellowChara"))
        {
            Debug.Log("4");
            botCollision = true;


            botVoidButton.gameObject.SetActive(false);
        }
        if (topCollision == true)
        {
            botVoidButton.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("YellowChara"))
        {
            topCollision = false;
        }

        botVoidButton.gameObject.SetActive(false);
    }

    public void BotVoidMove()
    {
        StartCoroutine(botClimb());

    }

    IEnumerator botClimb()
    {
        botMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        botMove = false;
        voidCol.enabled = true;
        player.GetComponent<PlayerMovement>().previousPosition = player.transform.position;
    }
}
