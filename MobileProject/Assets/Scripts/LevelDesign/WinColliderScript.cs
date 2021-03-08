using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinColliderScript : MonoBehaviour
{
    public GameObject winScreen;

    void Start()
    {
        winScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        winScreen.SetActive(true);
    }
}
