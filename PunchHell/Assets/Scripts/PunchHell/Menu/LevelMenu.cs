using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 6); 

        
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i < unlockedLevel;
        }
    }

    public void OpenLevel(int levelId)
    {
       
        PlayerPrefs.SetInt("CurrentLevel", levelId);
        SceneManager.LoadSceneAsync("Game"); 
    }
}
