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

    private bool botMove;
    private Vector3 velocity;
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
        botVoidButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
    }
}
