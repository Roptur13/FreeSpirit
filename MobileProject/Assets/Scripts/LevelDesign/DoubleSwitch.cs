using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwitch : MonoBehaviour
{
    public DoubleSwitch linkedSwitch;

    public bool isActivated;

    public GameObject objectToActive;

    private bool finish;

    public Sprite onSprite;
    public Sprite offSprite;

    private AudioSource audioSource;

    public AudioClip doorOpen;
    public AudioClip switchSound;

    void Start()
    {
        isActivated = false;

        finish = false;

        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (isActivated == true && linkedSwitch.isActivated == true && finish == false)
        {
            objectToActive.SetActive(false);
            audioSource.PlayOneShot(doorOpen);
            finish = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isActivated = true;
            audioSource.PlayOneShot(switchSound);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isActivated = false;
        }        
        
    }
}
