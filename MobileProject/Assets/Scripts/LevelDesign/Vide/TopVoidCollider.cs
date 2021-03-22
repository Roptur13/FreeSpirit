using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopVoidCollider : MonoBehaviour
{
    public Button topVoidButton;
    public GameObject player;

    void Start()
    {
        topVoidButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        topVoidButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        topVoidButton.gameObject.SetActive(false);
    }

    public void TopVoidMove()
    {
        player.transform.position += new Vector3(0, -2f, 0);

    }
}
