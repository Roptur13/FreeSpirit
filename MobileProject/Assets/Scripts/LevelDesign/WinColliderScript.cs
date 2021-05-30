using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

//Script de Noé

public class WinColliderScript : MonoBehaviour
{
    public GameObject winScreen;

    public int charactersNumber;

    [SerializeField]
    private int charactersArrived;

    public Button hubButton;

    public GameObject musicManager;

    public Volume volume;
    private Vignette vg;

    private bool postProcessFinished;

    public PlayerManager playerManager;

    public GameObject menu;

    void Start()
    {
        winScreen.SetActive(false);
        hubButton.gameObject.SetActive(false);

        if (volume != null)
        {
            volume.profile.TryGet(out vg);
        }       

        postProcessFinished = false;
    }

    void Update()
    {
        if (charactersArrived == charactersNumber)
        {
            transform.position = new Vector3(0, 0, 19); // déplace le collider car le son de victoire se joue qu'à la sortie (je sais pas pourquoi)
            if (postProcessFinished == false && volume != null)
            {
                StartCoroutine(RemovePostProcess());
                playerManager.StopCharacter(playerManager);
                menu.SetActive(false);
            }            
            musicManager.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
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

    private IEnumerator RemovePostProcess()
    {
        float progress = 0.0f;
        float animspeed = 0.5f;

        while (progress < 1.0f)
        {
            vg.intensity.value = Mathf.Lerp(vg.intensity.value, 0, 0.1f);

            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * animspeed;
        }

        postProcessFinished = true;
    }
}
