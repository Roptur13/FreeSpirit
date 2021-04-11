using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerMovement : MonoBehaviour
{

    private Vector3 targetPosition;
    public float moveSpeed;
    public bool canMove;

    private Vector3 previousPosition;
    
    void Start()
    {
        targetPosition = transform.position;        
    }
    
    void Update()
    {
        if (targetPosition == transform.position)
        {
            canMove = true;
            previousPosition = transform.position;
        }
        else
        {
            canMove = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed*Time.deltaTime);
    }

    public void Move(Vector3 movementDirection)
    {
        if (canMove == true)
        {
            targetPosition += movementDirection;
            Debug.Log(targetPosition);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetPosition = previousPosition;
    }
}
