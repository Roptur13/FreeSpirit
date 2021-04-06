using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightCollider : MonoBehaviour
{
    public Button rightButton;
    public GameObject mainBody;

    void Start()
    {
        rightButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rightButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rightButton.gameObject.SetActive(false);
    }

    public void RightMove()
    {
        mainBody.transform.position += new Vector3(0.25f, 0, 0);

    }
}
