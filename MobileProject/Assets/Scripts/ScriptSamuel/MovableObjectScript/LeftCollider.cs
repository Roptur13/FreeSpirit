using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCollider : MonoBehaviour
{
    public Button leftButton;
    public GameObject mainBody;

    void Start()
    {
        leftButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        leftButton.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        leftButton.gameObject.SetActive(false);
    }

    public void LeftMove()
    {
        mainBody.transform.position += new Vector3(0.5f, 0, 0);

    }
}
