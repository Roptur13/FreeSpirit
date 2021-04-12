using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class RightCollider : MonoBehaviour
{
    public Button rightButton;
    public GameObject mainBody;

    private bool rightMove;
    private Vector3 voidVelocity;

    void Start()
    {
        rightButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (rightMove == true)
        {
            voidVelocity = new Vector3(-1f, 0f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (rightMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            rightButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rightButton.gameObject.SetActive(false);
    }

    public void RightMove()
    {
        StartCoroutine(RightSlide());
    }

    IEnumerator RightSlide()
    {
        rightMove = true;
        yield return new WaitForSeconds(1.0f);
        rightMove = false;
    }
}
