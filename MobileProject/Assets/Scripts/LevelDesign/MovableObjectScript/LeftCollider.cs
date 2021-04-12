using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class LeftCollider : MonoBehaviour
{
    public Button leftButton;
    public GameObject mainBody;

    private bool leftMove;
    private Vector3 voidVelocity;

    void Start()
    {
        leftButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (leftMove == true)
        {
            voidVelocity = new Vector3(1f, 0f, 0f);
            mainBody.transform.position += voidVelocity * Time.deltaTime;
        }
        else if (leftMove == false)
        {
            mainBody.transform.position = mainBody.transform.position;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            leftButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftButton.gameObject.SetActive(false);
    }

    public void LeftMove()
    {
        StartCoroutine(LeftSlide());
    }

    IEnumerator LeftSlide()
    {
        leftMove = true;
        yield return new WaitForSeconds(1.0f);
        leftMove = false;
    }
}
