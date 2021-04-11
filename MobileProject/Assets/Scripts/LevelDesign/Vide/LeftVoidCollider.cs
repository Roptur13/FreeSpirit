using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script de Samuel
public class LeftVoidCollider : MonoBehaviour
{
    public Button leftVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;

    private bool leftMove;
    private Vector3 velocity;
    void Start()
    {
        leftVoidButton.gameObject.SetActive(false);
        leftMove = false;
    }

    private void Update()
    {
        if (leftMove == true)
        {
            velocity = new Vector3(2.0f, 0.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (leftMove == false)
        {
            player.transform.position = player.transform.position;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara"))
        {
            leftVoidButton.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftVoidButton.gameObject.SetActive(false);
    }

    public void LeftVoidMove()
    {
        StartCoroutine(leftGlide());
    }

    IEnumerator leftGlide()
    {
        leftMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        leftMove = false;
        voidCol.enabled = true;
    }
}
