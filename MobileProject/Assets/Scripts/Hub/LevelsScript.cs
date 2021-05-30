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

    public Image house1;
    public Image house2;
    public Image house3;

    public Sprite fixedHouse1;
    public Sprite fixedHouse2;
    public Sprite fixedHouse3;

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
            
            if (i < PlayerPrefs.GetInt("Max Level"))
            {
                levels[i].levelButton.gameObject.GetComponent<Image>().sprite = levels[i].afterSprite;
                if (i != 0 && i != 1 && i != 2)
                {
                    levels[i].levelButton.gameObject.GetComponent<Image>().SetNativeSize();
                }
                
                Debug.Log(levels[i].levelButton.gameObject.GetComponent<Image>().sprite);

                if (PlayerPrefs.GetInt("Max Level") >= 4)
                {
                    house1.sprite = fixedHouse1;
                    house1.SetNativeSize();
                }
                if (PlayerPrefs.GetInt("Max Level") >= 5)
                {
                    house2.sprite = fixedHouse2;
                    house2.SetNativeSize();
                }
                if (PlayerPrefs.GetInt("Max Level") >= 6)
                {
                    house3.sprite = fixedHouse3;
                    house3.SetNativeSize();
                }
            }
        }

        if (SaveSystem.newLevel == true)
        {
            levels[PlayerPrefs.GetInt("Max Level")].levelButton.gameObject.SetActive(true);
            levels[PlayerPrefs.GetInt("Max Level")].levelButton.gameObject.GetComponent<Image>().sprite = levels[PlayerPrefs.GetInt("Max Level")].beforeSprite; ;
        }
    }
    
}
