using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class TopCollider : MonoBehaviour
{
    public Button upButton;
    public GameObject mainBody;

    private bool topMove;
    private Vector3 voidVelocity;

    void Start()
    {
        upButton.gameObject.SetActive(false);
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
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            upButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        upButton.gameObject.SetActive(false);
    }

    public void TopMove()
    {
        StartCoroutine(TopSlide());
    }

    IEnumerator TopSlide()
    {
        topMove = true;
        yield return new WaitForSeconds(1.0f);
        topMove = false;
    }
}
