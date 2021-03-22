using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interrupter : MonoBehaviour
{
    //Albane

    public  GameObject door;

    private Color m_oldColor = Color.white;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Renderer render = GetComponent<Renderer>();

        m_oldColor = render.material.color;
        render.material.color = Color.green;

        
        door.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Renderer render = GetComponent<Renderer>();

        render.material.color = m_oldColor;

        door.SetActive(true);
    }
}
