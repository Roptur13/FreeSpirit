using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollidersArrays
{   
    public CameraPositionTrigger[] colliders;
}

public class CameraMovement : MonoBehaviour
{    
    
    public Vector3[] cameraPositions; //doit avoir une valeur de plus (la première) que colliderCategories, sa valeur importe peu car elle sert à éviter les out of range

    public CollidersArrays[] colliderCategories;

    [SerializeField]
    private int triggersActivated;

       
    void Start()
    {
        triggersActivated = 0;           
    }

    
    void Update()
    {
        for (int i = 0; i < colliderCategories.Length; i++)
        {
            for (int j = 0; j < colliderCategories[i].colliders.Length; j++)
            {               

                if (colliderCategories[i].colliders[j].activated == true)
                {
                    triggersActivated = triggersActivated + 1;
                }                
            }

            if (triggersActivated >= colliderCategories[i].colliders.Length)
            {
                transform.position = Vector3.Lerp(transform.position, cameraPositions[i + 1], 0.1f);
                triggersActivated = 0;
            }
            else
            {
                triggersActivated = 0;
            }
        }
    }
}
