using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script de Noé

public class LevelsScript : MonoBehaviour
{
    public List<Button> levels = new List<Button>();

    private void Awake()
    {
        levels[0].gameObject.SetActive(true);

        for (int i = 1; i < levels.Count; i++)
        {
            levels[i].gameObject.SetActive(false);
        }

        SaveSystem.CheckMaxLevel();
    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Max Level"));
        for (int i = 0; i < PlayerPrefs.GetInt("Max Level") + 1; i++)
        {
            levels[i].gameObject.SetActive(true);
            Debug.Log(levels[i].gameObject);
            if (i < PlayerPrefs.GetInt("Max Level") - 1)
            {
                //levels[i].GetComponent<Image>().sprite = nouvSprite //(ou quelque chose comme ça avec un shader)
            }
        }

        if (SaveSystem.newLevel == true)
        {
            levels[PlayerPrefs.GetInt("Max Level")].gameObject.SetActive(true);            
            //levels[PlayerPrefs.GetInt("Max Level")].GetComponent<Image>().sprite = nouvSprite //(ou quelque chose comme ça avec un shader et une coroutine)
        }
    }
    
}
