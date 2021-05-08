﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Noé

public class PlayerMovement : MonoBehaviour
{  

    public float moveSpeed;
    public bool canMove;
    public bool isJumping;

    public SwipeScript swipe;

    //private Animator animator;

    public float animValueX;
    public float animValueY;

    [SerializeField]
    public Vector3 previousPosition;

    [SerializeField]
    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
        isJumping = false;
        //animator = GetComponent<Animator>();        
    }
    
    void Update()
    {
        if (targetPosition == transform.position)
        {
            canMove = true;
            previousPosition = transform.position;

            animValueX = 0f;
            animValueY = 0f;
        }
        else
        {
            canMove = false;
        }

        if (isJumping == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //animator.SetFloat("Move X", animValueX);
            //animator.SetFloat("Move Y", animValueY);
        }
        
    }

    public void Move(Vector3 movementDirection)
    {
        if (canMove == true)
        {
            targetPosition += movementDirection;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetPosition = previousPosition;
        animValueX = -animValueX;
        animValueY = -animValueY;
    }
}
