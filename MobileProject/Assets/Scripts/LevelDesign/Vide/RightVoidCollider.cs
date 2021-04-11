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

    private bool rightMove;
    private Vector3 velocity;

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
        StartCoroutine(rightGlide());
    }

    IEnumerator rightGlide()
    {
        rightMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        rightMove = false;
        voidCol.enabled = true;
    }
}
