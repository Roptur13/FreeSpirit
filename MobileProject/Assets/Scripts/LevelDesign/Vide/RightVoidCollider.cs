using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class RightVoidCollider : MonoBehaviour
{
    public Button rightVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool rightCollision;
    public bool leftCollision;
    public LeftVoidCollider leftVoidCollider;

    private bool rightMove;
    private Vector3 velocity;

    //public Vector3 previousPosition;

    void Start()
    {
        rightVoidButton.gameObject.SetActive(false);
        rightMove = false;
    }

    private void Update()
    {
        if (rightMove == true)
        {
            velocity = new Vector3(-2.0f, 0.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (rightMove == false)
        {
            player.transform.position = player.transform.position;
        }

        leftCollision = leftVoidCollider.leftCollision;
        //Debug.Log(leftCollision);
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") )
        {
            if (leftCollision == false)
            {
                rightVoidButton.gameObject.SetActive(true);
            }
            Debug.Log("yellowChara");
        }
        else
        {
            Debug.Log("1");
            rightCollision = true;  

            rightVoidButton.gameObject.SetActive(false);
        }
        if (leftCollision == true)
        {
            rightVoidButton.gameObject.SetActive(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("YellowChara"))
        {
            rightCollision = false;
        }

        rightVoidButton.gameObject.SetActive(false);
    }

    public void RightVoidMove()
    {
        StartCoroutine(rightGlide());
    }

    IEnumerator rightGlide()
    {
        rightMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        rightMove = false;
        voidCol.enabled = true;
        player.GetComponent<PlayerMovement>().previousPosition = player.transform.position;
    }
}
