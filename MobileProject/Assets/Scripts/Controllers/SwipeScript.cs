using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class SwipeScript : MonoBehaviour
{

    public PlayerManager playerManager;
    private Vector2 startposition;
    private bool fingerDown;
    public int pixelDistToDetect = 20;
    public GameObject currentCharacter;
    public PlayerMovement movement;
    public int distance;

    public int swipeCount = 0;

    
    void Update()
    {
        SwipeDetection();

        currentCharacter = playerManager.currentCharacter;
        movement = currentCharacter.GetComponent<PlayerMovement>();
        
    }

    void SwipeDetection()
    {
        if (fingerDown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startposition = Input.touches[0].position;
            fingerDown = true;
        }

        if (fingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerDown = false;
        }

        if (fingerDown)
        {
            if(Input.touches[0].position.y >= startposition.y + pixelDistToDetect) //swipe haut
            {
                fingerDown = false;
                movement.Move(Vector3.up * distance);
                swipeCount = swipeCount + 1;
            }
            else if(Input.touches[0].position.x <= startposition.x - pixelDistToDetect) //swipe gauche
            {
                fingerDown = false;
                movement.Move(Vector3.left * distance);
                swipeCount = swipeCount + 1;
            }
            else if (Input.touches[0].position.x >= startposition.x + pixelDistToDetect) //swipe droit
            {
                fingerDown = false;
                movement.Move(Vector3.right * distance);
                swipeCount = swipeCount + 1;
            }
            else if (Input.touches[0].position.y <= startposition.y - pixelDistToDetect) //swipe bas
            {
                fingerDown = false;
                movement.Move(Vector3.down * distance);
                swipeCount = swipeCount + 1;
            }

            if (fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }

        }
    }
}
