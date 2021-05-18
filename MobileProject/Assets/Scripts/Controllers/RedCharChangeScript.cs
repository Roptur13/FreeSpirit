using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCharChangeScript : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerYellow;
    public GameObject RedSwitch;
    public GameObject YellowSwitch;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playerYellow)
        {
            playerRed.transform.position = playerYellow.transform.position;
            StartCoroutine(playerChange());
        }

    }

    IEnumerator playerChange()
    {
        yield return new WaitForSeconds(0.1f);
        playerYellow.transform.position = playerYellow.transform.position + new Vector3(0f, 1f, 0f);
        playerMovement.previousPosition = playerYellow.transform.position;
        playerMovement.targetPosition = playerYellow.transform.position;
        playerYellow.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        playerRed.transform.position = playerYellow.transform.position + new Vector3(0f, -1f, 0f);
        playerRed.SetActive(true);       
        YellowSwitch.SetActive(false);
        RedSwitch.SetActive(true);
    }
}
