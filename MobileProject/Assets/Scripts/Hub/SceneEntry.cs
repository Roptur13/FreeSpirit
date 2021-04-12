using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Albane

public class SceneEntry : MonoBehaviour
{
#if UNITY_EDITOR
    public UnityEngine.Object scene;
#endif

    [HideInInspector]
    [SerializeField]
    string sceneToLoad = "";

#if UNITY_EDITOR
    public void OnValidate()
    {
        sceneToLoad = "";

        if (scene != null)
        {
            if (scene.ToString().Contains("(UnityEngine.SceneAsset)"))
            {
                sceneToLoad = scene.name;
            }
            else
            {
                scene = null;
            }
        }
    }
#endif

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
