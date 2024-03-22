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
        int nextLevel = StageManager.Instance.Level + 1;
        StageManager.Instance.Level = nextLevel;

        // Ensure the stage is reset and ready for the next level
        StageManager.Instance.ResetStageValues(); // Reset stage values if necessary
        StageManager.Instance.ActionManager.StopStage(); // Stop the current stage actions

        // Begin the next stage
        StageManager.Instance.ActionManager.SetActions(StageDefinitions.GetLevelDefinition(nextLevel));
        StageManager.Instance.ActionManager.BeginStage();

        gameObject.SetActive(false); // Hide victory screen
    }

    public void OnQuitClicked()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
        StageManager.Instance.ResetStageValues();
        StageManager.Instance.Paused = false;
    }

    public void onRestartClicked()
    {
        gameObject.SetActive(false);

        // Reset stage values to their initial state
        //StageManager.Instance.ResetStageValues();
    
        // Stop the current stage actions if any are running
        //StageManager.Instance.ActionManager.StopStage();
    
        // Get the current level's actions and begin the stage again
        StageManager.Instance.Level = StageManager.Instance.Level;
    }
}
