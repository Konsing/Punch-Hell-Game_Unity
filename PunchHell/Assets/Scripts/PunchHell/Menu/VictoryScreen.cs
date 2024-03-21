using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]
    private Button nextLevelButton;

    [SerializeField]
    private Button quitButton;

    
    public void NextLevelClicked()
    {
        StageManager.Instance.Level += 1;
        StageManager.Instance.ActionManager.BeginStage();
        gameObject.SetActive(false);
    }

    public void OnQuitClicked()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
        StageManager.Instance.Paused = false;
    }

    public void onRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
