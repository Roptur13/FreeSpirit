using UnityEngine;

public class Interrupter : MonoBehaviour
{
    //Albane

    public  GameObject door;
    public bool simplePush = true;
    private bool isOpen;

    private Renderer render;

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

            if (simplePush == false)
            {
                door.SetActive(true);
                isOpen = false;
            }
                

        }
        
        
    }
}
