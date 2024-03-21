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

    public void onRestartClicked()
    {
        gameObject.SetActive(false);

        // Stop any current stage actions
        StageManager.Instance.ActionManager.StopStage();
    
        // Destroy all existing enemies
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }
    
        // Reset stage values to their initial state
        StageManager.Instance.ResetStageValues();
    
        // Get the current level's actions and begin the stage again
        int currentLevel = StageManager.Instance.Level;
        StageManager.Instance.ActionManager.SetActions(StageDefinitions.GetLevelDefinition(currentLevel));
        StageManager.Instance.ActionManager.BeginStage();
    }
}
