using UnityEngine;
using UnityEngine.UI;


//Script de Noé

public class DestructibleWall : MonoBehaviour
{
    public GameObject player;
    public Button destroyButton;
    private PlayerController playerController;

    [SerializeField]
    private float distance;

    void Start()
    {
        destroyButton.gameObject.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
    }

    
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if(distance<=1.2f && playerController.color == PlayerController.characterColor.Red)
        {
            destroyButton.gameObject.SetActive(true);
        }
        else
        {
            destroyButton.gameObject.SetActive(false);
        }
    }

    public void BlockDestroy(Collider2D collider)
    {
        Destroy(destroyButton.gameObject);
        Destroy(gameObject);     
    }
}
