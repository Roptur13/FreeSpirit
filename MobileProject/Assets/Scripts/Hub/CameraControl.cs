using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Albane

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 dragOrigine;

    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
            dragOrigine = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigine - cam.ScreenToWorldPoint(Input.mousePosition);

            print("origin" + dragOrigine + "newPosition" + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference " + difference);

            cam.transform.position += difference;
        }
    }
}
