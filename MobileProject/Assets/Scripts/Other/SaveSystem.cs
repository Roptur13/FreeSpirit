using UnityEngine;
using UnityEngine.SceneManagement;

// Script de Noé

public class SaveSystem 
{
    public static bool newLevel = false;

    public static void SaveFinishedLevel()
    {
        PlayerPrefs.SetInt("Last Level Finished", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public static void SaveMaxLevel()
    {
        PlayerPrefs.SetInt("Previous Max Level", PlayerPrefs.GetInt("Max Level"));
        PlayerPrefs.SetInt("Max Level", PlayerPrefs.GetInt("Last Level Finished") - 1);
        PlayerPrefs.Save();
    }

    public static void CheckMaxLevel()
    {
        if (PlayerPrefs.HasKey("Max Level") == true)
        {
            if (PlayerPrefs.HasKey("Last Level Finished") == true)
            {
                int lastLevelFinished = PlayerPrefs.GetInt("Last Level Finished");
                int maxLevel = PlayerPrefs.GetInt("Max Level");

                if (lastLevelFinished > maxLevel)
                {
                    SaveMaxLevel();
                    newLevel = true;
                }
                else
                {
                    newLevel = false;
                }
            }            
        }
        else
        {
            SaveMaxLevel();
        }
    }
}
