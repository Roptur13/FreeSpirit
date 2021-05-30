using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script de Noé

[System.Serializable]
public class ButtonManager
{
    public Button levelButton;
    public Sprite beforeSprite;
    public Sprite afterSprite;
}


public class LevelsScript : MonoBehaviour
{
    public List<ButtonManager> levels;

    private void Awake()
    {
        levels[0].levelButton.gameObject.SetActive(true);

        for (int i = 1; i < levels.Count; i++)
        {
            levels[i].levelButton.gameObject.SetActive(false);
        }

        SaveSystem.CheckMaxLevel();
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Max Level"));
        for (int i = 0; i < PlayerPrefs.GetInt("Max Level") + 1; i++)
        {
            levels[i].levelButton.gameObject.SetActive(true);
            //Debug.Log(levels[i].gameObject);
            if (i < PlayerPrefs.GetInt("Max Level") - 1)
            {
                levels[i].levelButton.gameObject.GetComponent<Image>().sprite = levels[i].afterSprite;
            }
        }

        if (SaveSystem.newLevel == true)
        {
            levels[PlayerPrefs.GetInt("Max Level")].levelButton.gameObject.SetActive(true);
            levels[PlayerPrefs.GetInt("Max Level")].levelButton.gameObject.GetComponent<Image>().sprite = levels[PlayerPrefs.GetInt("Max Level")].beforeSprite; ;
        }
    }
    
}
