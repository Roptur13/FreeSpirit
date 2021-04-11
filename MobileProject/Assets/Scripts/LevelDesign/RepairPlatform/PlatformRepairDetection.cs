using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlatformRepairDetection : MonoBehaviour
{
    public Button RepairButton;
    // Start is called before the first frame update
    void Start()
    {
        RepairButton.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RepairButton.gameObject.SetActive(true);
        Debug.Log("playerdetect");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RepairButton.gameObject.SetActive(false);
    }
}
