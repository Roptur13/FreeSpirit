using System.Collections;

using UnityEngine;

public class YellowCharChangeScript : MonoBehaviour
{
    public GameObject playerRed;
    public GameObject playerYellow;
    public GameObject YellowSwitch;
    public GameObject RedSwitch;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == playerRed)
        {
            playerYellow.transform.position = playerRed.transform.position;
            StartCoroutine(playerChange());
        }      
    }

    IEnumerator playerChange()
    {
        yield return new WaitForSeconds(0.1f);
        playerRed.transform.position = playerRed.transform.position + new Vector3(0f, -1f, 0f);
        playerMovement.previousPosition = playerRed.transform.position;
        playerMovement.targetPosition = playerRed.transform.position;
        playerRed.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        playerYellow.transform.position = playerRed.transform.position + new Vector3(0f, 1f, 0f);
        playerYellow.SetActive(true);
        YellowSwitch.SetActive(true);
        RedSwitch.SetActive(false);
    }
}
