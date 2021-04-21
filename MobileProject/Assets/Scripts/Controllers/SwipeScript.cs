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
    public List<PlayerMovement> movement = new List<PlayerMovement>();
    public int distance;

    public int swipeCount = 0;

    private void Start()
    {
        if(playerManager.sameMovements == true)
        {
            for (int i = 0; i < playerManager.characters.Count; i++)
            {
                movement.Add(playerManager.characters[i].GetComponent<PlayerMovement>());                
            }
            movement.RemoveAt(0);
        }
    }

    void Update()
    {
        SwipeDetection();

        currentCharacter = playerManager.currentCharacter;

        if (playerManager.sameMovements == false)
        {
            movement[0] = currentCharacter.GetComponent<PlayerMovement>();
        }     
          
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

                for (int i = 0; i < movement.Count; i++)
                {
                    movement[i].Move(Vector3.up * distance);
                    movement[i].animValueX = 0f;
                    movement[i].animValueY = 0.5f;
                }                

                swipeCount = swipeCount + 1;
            }
            else if(Input.touches[0].position.x <= startposition.x - pixelDistToDetect) //swipe gauche
            {
                fingerDown = false;

                for (int i = 0; i < movement.Count; i++)
                {
                    movement[i].Move(Vector3.left * distance);
                    movement[i].animValueX = -0.5f;
                    movement[i].animValueY = 0f;
                }                

                swipeCount = swipeCount + 1;
            }
            else if (Input.touches[0].position.x >= startposition.x + pixelDistToDetect) //swipe droit
            {
                fingerDown = false;

                for (int i = 0; i < movement.Count; i++)
                {
                    movement[i].Move(Vector3.right * distance);
                    movement[i].animValueX = 0.5f;
                    movement[i].animValueY = 0f;
                }                

                swipeCount = swipeCount + 1;
            }
            else if (Input.touches[0].position.y <= startposition.y - pixelDistToDetect) //swipe bas
            {
                fingerDown = false;

                for (int i = 0; i < movement.Count; i++)
                {
                    movement[i].Move(Vector3.down * distance);
                    movement[i].animValueX = 0f;
                    movement[i].animValueY = -0.5f;
                }                

                swipeCount = swipeCount + 1;
            }

            if (fingerDown && Input.GetMouseButtonUp(0))
            {
                fingerDown = false;
            }

        }
    }
}
