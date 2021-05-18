using UnityEngine;
using UnityEngine.UI;

public class WinColliderScript : MonoBehaviour
{
    public GameObject winScreen;

    public int charactersNumber;

    private int charactersArrived;

    public Button hubButton;

    void Start()
    {
        winScreen.SetActive(false);
        hubButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (charactersArrived == charactersNumber)
        {
            winScreen.SetActive(true);
            hubButton.gameObject.SetActive(true);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            charactersArrived++;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueChara") || collision.gameObject.layer == LayerMask.NameToLayer("YellowChara") || collision.gameObject.layer == LayerMask.NameToLayer("RedChara"))
        {
            charactersArrived--;
        }
    }

    public void SaveThisLevel()
    {
        SaveSystem.SaveFinishedLevel();
        Debug.Log(PlayerPrefs.GetInt("Last Level Finished"));
    }
}
