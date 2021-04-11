using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class BotCollider : MonoBehaviour
{
    public Button botButton;
    public GameObject mainBody;

    void Start()
    {
        botButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        botButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        botButton.gameObject.SetActive(false);
    }

    public void BotMove()
    {
        mainBody.transform.position += new Vector3(0, 1f, 0);

    }
}
