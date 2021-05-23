﻿using UnityEngine;
using UnityEngine.UI;

//Script de Noé

public class WinColliderScript : MonoBehaviour
{
    public GameObject winScreen;

    public int charactersNumber;

    [SerializeField]
    private int charactersArrived;

    public Button hubButton;

    public GameObject musicManager;

    void Start()
    {
        winScreen.SetActive(false);
        hubButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (charactersArrived == charactersNumber)
        {
            transform.position = new Vector3(0, 0, 19); // déplace le collider car le son de victoire se joue qu'à la sortie (je sais pas pourquoi)
            winScreen.SetActive(true);
            musicManager.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            hubButton.gameObject.SetActive(true);
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

    public void SaveThisLevel()
    {
        SaveSystem.SaveFinishedLevel();
        Debug.Log(PlayerPrefs.GetInt("Last Level Finished"));
    }
}
