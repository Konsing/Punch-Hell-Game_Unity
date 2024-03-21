using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    public int Level 
    { 
        get => currentLevel;
        set
        {
            if (value == currentLevel)
                return;

            actionManager.StopStage();
            actionManager.SetActions(StageDefinitions.GetLevelDefinition(value));
            currentLevel = value;
            FindFirstObjectByType<PauseMenu>(FindObjectsInactive.Include)
                .GetComponentInChildren<Text>().text = $"Stage {currentLevel}";
        }
    }

    private StageActionManager actionManager;

    private bool paused = false;
    private bool dialogueActive = false;
    private int currentLevel = 1;

    public bool Paused 
    { 
        get => dialogueActive || paused; 
        set
        {
            FindFirstObjectByType<PauseMenu>(FindObjectsInactive.Include).gameObject.SetActive(value);
            var isPaused = value || dialogueActive;
            Time.timeScale = isPaused ? 0.0f : 1.0f;
            paused = value;
        }
    }

    public bool DialogueActive
    {
        get => dialogueActive;
        set
        {
            var isPaused = value || paused;
            Time.timeScale = isPaused ? 0.0f : 1.0f;
            dialogueActive = value;
        }
    }

    public int LivesRemaining 
    { 
        get => livesRemaining;
        set
        {
            livesRemaining = value;
            if (livesRemaining <= 0)
            {

            }
        }
    }

    private int livesRemaining = 3;
    private int score = 0;
    private int power = 0;
    private int powerLevel = 1;
    private int rollLevel = 0;

    public void AddScore(int addedScore)
    {
        score += addedScore;
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString().PadLeft(6, '0');
    }

    public void AddPower(int addedPower)
    {
        power += addedPower;
        GameObject.Find("PowerBar").GetComponent<Image>().fillAmount = power / 100.0f;
    }

    public void AddRoll(int addedRoll)
    {
        rollLevel += addedRoll;
    }

    public void ResetStageValues()
    {
        livesRemaining = 3;
        score = 0;
        power = 0;
        rollLevel = 0;
        powerLevel = 1;
    }

    void Start()
    {
        Instance = this;

        actionManager = GetComponent<StageActionManager>();
        actionManager.SetActions(StageDefinitions.GetLevelDefinition(currentLevel));
        actionManager.BeginStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
