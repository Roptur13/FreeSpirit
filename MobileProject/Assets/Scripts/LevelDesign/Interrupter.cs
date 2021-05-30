using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupter : MonoBehaviour
{
    //Albane

    public  GameObject door;
    public bool simplePush = true;
    private bool isOpen;

    private Renderer render;

    private Color m_oldColor = Color.white;

    private AudioSource audioSource;

    public AudioClip doorOpen;
    public AudioClip switchSound;

    private void Start()
    {
        render = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();
        isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            m_oldColor = render.material.color;
            //render.material.color = Color.green;
            audioSource.PlayOneShot(switchSound);

            if (isOpen == false)
            {
                audioSource.PlayOneShot(doorOpen);
            }

            isOpen = true;

            door.SetActive(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //render.material.color = m_oldColor;

            if (simplePush == false)
            {
                door.SetActive(true);
                isOpen = false;
            }
                

        }
        
        
    }
}
