using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinColliderScript : MonoBehaviour
{
    public GameObject winScreen;

    public int charactersNumber;

    private int charactersArrived;

    void Start()
    {
        winScreen.SetActive(false);
    }

    void Update()
    {
        if (charactersArrived == charactersNumber)
        {
            winScreen.SetActive(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            charactersArrived++;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            charactersArrived--;
        }
    }
}
