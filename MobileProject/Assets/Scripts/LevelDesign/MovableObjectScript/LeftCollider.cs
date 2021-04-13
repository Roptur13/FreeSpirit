using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class LeftCollider : MonoBehaviour
{
    public Button leftButton;
    public GameObject mainBody;
    public bool obstacleLeft;
    public bool obstacleRight;
    public RightCollider rightCollider;

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

        obstacleRight = rightCollider.obstacleRight;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara")) && obstacleRight == false)
        {
            leftButton.gameObject.SetActive(true);

        } 
        else if ((collision.gameObject.layer != LayerMask.NameToLayer("YellowChara") && collision.gameObject.layer != LayerMask.NameToLayer("BlueChara") && collision.gameObject.layer != LayerMask.NameToLayer("RedChara")))
        {
            obstacleLeft = true;
        }

        if (obstacleRight == true)
        {
            leftButton.gameObject.SetActive(false);
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
