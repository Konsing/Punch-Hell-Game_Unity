using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        ResolutionUtility.ForceGameResolution();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
