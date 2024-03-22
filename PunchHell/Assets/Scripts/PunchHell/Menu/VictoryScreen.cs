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

        
        StageManager.Instance.ResetStageValues(); 
        StageManager.Instance.ActionManager.StopStage(); 

        
        StageManager.Instance.ActionManager.SetActions(StageDefinitions.GetLevelDefinition(nextLevel));
        StageManager.Instance.ActionManager.BeginStage();

        gameObject.SetActive(false); 
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

        // Stop any current stage actions
        StageManager.Instance.ResetStageValues();
        StageManager.Instance.ActionManager.StopStage();
    
        StageManager.Instance.Level = StageManager.Instance.Level;
    }
}
