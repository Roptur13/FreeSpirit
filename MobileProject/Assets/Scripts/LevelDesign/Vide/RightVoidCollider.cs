using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightVoidCollider : MonoBehaviour
{
    public Button rightVoidButton;
    public GameObject player;

    void Start()
    {
        rightVoidButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rightVoidButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rightVoidButton.gameObject.SetActive(false);
    }

    public void RightVoidMove()
    {
        player.transform.position += new Vector3(-2f, 0, 0);

    }
}
