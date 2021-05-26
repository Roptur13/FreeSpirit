using System.Collections;
using UnityEngine;

[System.Serializable]
public class CameraPossibleSettings
{   
    public Vector3 camPossiblePosition;
    public float camPossibleSize;
}

public class CameraMovement : MonoBehaviour
{

    public Vector3[] cameraPositions;

    public CameraPossibleSettings[] camSettings;

    Camera mainCam;

    private int index;


    void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    public void MoveCamera(int arrayChosenIndex)
    {
        index = arrayChosenIndex;
        StartCoroutine(Move());
    }

    public IEnumerator Move()
    {
        float progress = 0.0f;
        float animspeed = 0.5f;

        while (progress <1.0f)
        {
            transform.position = Vector3.Lerp(transform.position, camSettings[index].camPossiblePosition, 0.1f);
            mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, camSettings[index].camPossibleSize, 0.1f);

            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * animspeed;
        }        
    }
}
