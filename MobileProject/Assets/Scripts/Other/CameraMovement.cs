using UnityEngine;

[System.Serializable]
public class CollidersArrays
{   
    public CameraPositionTrigger[] colliders;
}

public class CameraMovement : MonoBehaviour
{    
    
    public Vector3[] cameraPositions; 

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
                transform.position = Vector3.Lerp(transform.position, cameraPositions[i], 0.1f);
                triggersActivated = 0;
            }
            else
            {
                triggersActivated = 0;
            }
        }
    }
}
