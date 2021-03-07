using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopCollider : MonoBehaviour
{
    public Button upButton;
    public GameObject mainBody;

    void Start()
    {
        upButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        upButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        upButton.gameObject.SetActive(false);
    }

    public void TopMove()
    {
        mainBody.transform.position += new Vector3(0, -0.5f, 0);
        
    }
}
