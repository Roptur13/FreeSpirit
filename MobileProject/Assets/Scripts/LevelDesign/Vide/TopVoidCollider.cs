using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//script de Samuel
public class TopVoidCollider : MonoBehaviour
{
    public Button topVoidButton;
    public GameObject player;
    public BoxCollider2D voidCol;
    public bool botCollision;
    public bool topCollision;
    public BotVoidCollider botVoidCollider;

    private bool topMove;
    private Vector3 velocity;

    //public Vector3 previousPosition;

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

        botCollision = botVoidCollider.botCollision;
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") && botCollision == false)
        {
            topVoidButton.gameObject.SetActive(true);
        }
        else if (collision.gameObject.layer != LayerMask.NameToLayer("YellowChara"))
        {
            Debug.Log("3");
            topCollision = true;


            topVoidButton.gameObject.SetActive(false);
        }
        if (botCollision == true)
        {
            topVoidButton.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("YellowChara"))
        {
            topCollision = false;
        }

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
        player.GetComponent<PlayerMovement>().previousPosition = player.transform.position;
    }
    
}
