using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TopVoidCollider : MonoBehaviour
{
    public Button topVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;

    private bool topMove;
    private Vector3 velocity;
    void Start()
    {
        topVoidButton.gameObject.SetActive(false);
        topMove = false;
    }

    private void Update()
    {
        if (topMove == true)
        {
            velocity = new Vector3(0.0f, -2.0f, 0.0f);
            player.transform.position += velocity * Time.deltaTime;
        }
        else if (topMove == false)
        {
            player.transform.position = player.transform.position;
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        topVoidButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        topVoidButton.gameObject.SetActive(false);
    }

    public void TopVoidMove()
    {
        StartCoroutine(topFall());
    }

     IEnumerator topFall()
    {
        topMove = true;
        voidCol.enabled = !voidCol.enabled;
        yield return new WaitForSeconds(1.0f);
        topMove = false;
        voidCol.enabled = true;
    }
    
}
