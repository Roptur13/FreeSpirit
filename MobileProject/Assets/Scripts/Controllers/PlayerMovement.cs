using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerMovement : MonoBehaviour
{

    private Vector2 targetPosition;
    public float moveSpeed;
    
    void Start()
    {
        targetPosition = transform.position;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void Move(Vector2 movementDirection)
    {
        targetPosition += movementDirection;
    }
}
