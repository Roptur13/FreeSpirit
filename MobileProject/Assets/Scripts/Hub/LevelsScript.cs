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
        for (int i = 0; i < levels.Count; i++)
        {
            levels[i].gameObject.SetActive(false);
        }

        SaveSystem.CheckMaxLevel();
    }

    void Start()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Max Level"); i++)
        {
            levels[i].gameObject.SetActive(true);
            if (i < PlayerPrefs.GetInt("Max Level") - 1)
            {
                //levels[i].GetComponent<Image>().sprite = nouvSprite //(ou quelque chose comme ça avec un shader)
            }
        }

        if (SaveSystem.newLevel == true)
        {
            levels[PlayerPrefs.GetInt("Max Level") + 1].gameObject.SetActive(true);
            //levels[PlayerPrefs.GetInt("Max Level")].GetComponent<Image>().sprite = nouvSprite //(ou quelque chose comme ça avec un shader et une coroutine)
        }
    }
    
}
