using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupter : MonoBehaviour
{
    //Albane

    public  GameObject door;
    public bool simplePush = true;

    private Renderer render;

    private Color m_oldColor = Color.white;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            m_oldColor = render.material.color;
            render.material.color = Color.green;


            door.SetActive(false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            render.material.color = m_oldColor;

            if (simplePush == false)
                door.SetActive(true);
        }
        
        
    }
}
