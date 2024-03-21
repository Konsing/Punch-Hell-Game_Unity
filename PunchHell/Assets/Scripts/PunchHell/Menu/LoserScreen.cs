using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoserScreen : MonoBehaviour
{
    [SerializeField]
    private Button newGameButton;

    [SerializeField]
    private Button quitButton;

    
    public void OnNewGameClicked()
    {
        StageManager.Instance.Level = 1;
        StageManager.Instance.ActionManager.BeginStage();
        gameObject.SetActive(false);
    }

    public void OnQuitClicked()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
        StageManager.Instance.Paused = false;
    }
}
