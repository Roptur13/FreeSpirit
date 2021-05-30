using UnityEngine;

//Script de Noé

public class PlayerController : MonoBehaviour
{
    public PlayerManager playerManager;

    public GameObject highLight;

    public bool blue;
    public bool red;
    public bool yellow;

    private void Update()
    {
        /*if (this.gameObject == playerManager.currentCharacter)
        {
            highLight.SetActive(true);
        }
        else
        {
            highLight.SetActive(false);
        }*/
    }

    private void OnMouseDown()
    {
        playerManager.currentCharacter.GetComponent<PlayerController>().highLight.SetActive(false);
        playerManager.ChangeCharacter(this.gameObject);
        GetComponent<PlayerMovement>().enabled = true;
        highLight.SetActive(true);
    }
}
