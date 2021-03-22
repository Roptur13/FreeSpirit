using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotVoidCollider : MonoBehaviour
{
    public Button botVoidButton;
    public GameObject player;

    void Start()
    {
        botVoidButton.gameObject.SetActive(false);
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
        player.transform.position += new Vector3(0, 2f, 0);

    }
}
