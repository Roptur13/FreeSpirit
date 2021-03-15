using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script de Noé

public class PlayerController : MonoBehaviour
{
    public enum characterColor { Red, Blue, Yellow, Purple, Orange, Green };
    public characterColor color;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }
}
