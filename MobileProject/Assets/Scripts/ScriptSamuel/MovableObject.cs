using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player" && Input.GetButtonDown("LeftClick"))
        {
            
        }
    }

}
