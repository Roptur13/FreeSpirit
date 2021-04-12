using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class BotCollider : MonoBehaviour
{
    public Button botButton;
    public GameObject mainBody;

    private bool botMove;
    private Vector3 voidVelocity;

    void Start()
    {
        botButton.gameObject.SetActive(false);
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
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            botButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        botButton.gameObject.SetActive(false);
    }

    public void BotMove()
    {
        StartCoroutine(BotSlide());
    }

    IEnumerator BotSlide()
    {
        botMove = true;
        yield return new WaitForSeconds(1.0f);
        botMove = false;
    }
}
