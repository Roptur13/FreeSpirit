using UnityEngine;

public class CameraPositionTrigger : MonoBehaviour
{
    public bool activated;

    private void Start()
    {
        activated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        activated = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activated = false;
    }
}
