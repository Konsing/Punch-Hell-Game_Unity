using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Button quitButton;

    void Awake()
    {
        quitButton.onClick.AddListener(OnQuitClicked);
    }

    public void OnQuitClicked()
    {
        Debug.Log("Quit clicked");
        SceneManager.LoadSceneAsync("TitleScreen");
        StageManager.Instance.ResetStageValues();
        StageManager.Instance.Paused = false;
    }
}
