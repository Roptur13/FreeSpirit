using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftVoidCollider : MonoBehaviour
{
    public Button leftVoidButton;
    public GameObject player;

    void Start()
    {
        leftVoidButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftVoidButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftVoidButton.gameObject.SetActive(false);
    }

    public void LeftVoidMove()
    {
        player.transform.position += new Vector3(2f, 0, 0);

    }
}
