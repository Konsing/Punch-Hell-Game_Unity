using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 3;
    public List<AudioClip> levelMusicClips = new List<AudioClip>();

    public static StageManager Instance { get; private set; }
    public StageActionManager ActionManager { get => actionManager; }
    private StageActionManager actionManager;
    private LifeBar lifeBar;

    private bool paused = false;
    private bool dialogueActive = false;
    private int currentLevel = 1;
    private int livesRemaining;
    private int score = 0;
    private int power = 0;
    private int powerLevel = 1;
    private int rollLevel = 0;

    public int Level 
    { 
        get => currentLevel;
        set
        {
            currentLevel = value;

            foreach (var obj in GameObject.FindGameObjectsWithTag("Enemy"))
                Destroy(obj);

            actionManager.StopStage();
            actionManager.SetActions(StageDefinitions.GetLevelDefinition(value));
            FindFirstObjectByType<PauseMenu>(FindObjectsInactive.Include)
                .GetComponentInChildren<Text>().text = $"Stage {currentLevel}";
            ResetStageValues();
            actionManager.BeginStage();

            // Handle background music change
            var backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            // Assuming you have a method to get the appropriate AudioClip based on the current level
            AudioClip newLevelMusic = GetMusicClipForLevel(currentLevel);
            if (backgroundMusic != null && newLevelMusic != null)
            {
                backgroundMusic.clip = newLevelMusic;
                backgroundMusic.Play();
            }
        }
    }

    private AudioClip GetMusicClipForLevel(int level)
    {
        if (level - 1 < levelMusicClips.Count)
        {
            return levelMusicClips[level - 1];
        }
        else
        {
            Debug.LogWarning("No music clip found for level " + level);
            return null;
        }
    }

    public bool Paused 
    { 
        get => dialogueActive || paused; 
        set
        {
            FindFirstObjectByType<PauseMenu>(FindObjectsInactive.Include).gameObject.SetActive(value);
            Time.timeScale = (value || dialogueActive) ? 0.0f : 1.0f;
            paused = value;
        }
    }

    public bool DialogueActive
    {
        get => dialogueActive;
        set
        {
            Time.timeScale = (value || paused) ? 0.0f : 1.0f;
            dialogueActive = value;
        }
    }

    public int LivesRemaining 
    { 
        get => livesRemaining;
        set
        {
            if (value < livesRemaining)
            {
                AddPower(-power);
                powerLevel = Mathf.Max(powerLevel - 1, 1);
                PlayerController.Instance.SetTurretsEnabled(powerLevel);
            }

            livesRemaining = value;
            lifeBar.SetHeartsVisible(livesRemaining);

            if (livesRemaining <= 0)
            {
                PlayerController.Instance.gameObject.SetActive(false);
                FindFirstObjectByType<LoserScreen>(FindObjectsInactive.Include).gameObject.SetActive(true);
            }
            else
            {
                PlayerController.Instance.gameObject.SetActive(true);
            }
        }
    }

    public int RollLevel
    {
        get => rollLevel;
    }

    public void AddScore(int addedScore)
    {
        score += addedScore;
        GameObject.Find("Score").GetComponent<Text>().text = score.ToString().PadLeft(6, '0');
    }

    public void AddPower(int addedPower)
    {
        if (power >= 100 && powerLevel == 3)
            return;

        power += addedPower;

        if (power >= 100)
        {
            if (powerLevel == 1)
                power = 0;
            else if (powerLevel == 2)
                power = 100;

            powerLevel += 1;
            PlayerController.Instance.SetTurretsEnabled(powerLevel);
        }

        GameObject.Find("PowerBar").GetComponent<Image>().fillAmount = power / 100.0f;
    }

    public void AddRoll(int addedRoll)
    {
        rollLevel += addedRoll;
        rollLevel = Mathf.Min(100, rollLevel);
        GameObject.Find("RollBar").GetComponent<Image>().fillAmount = rollLevel / 100.0f;
    }

    public void ResetStageValues()
    {
        LivesRemaining = maxLives;
        AddScore(-score);
        AddPower(-power);
        AddRoll(-rollLevel);
        powerLevel = 1;
        PlayerController.Instance.gameObject.SetActive(true);
        PlayerController.Instance.transform.position = new Vector3(640, 400, 0);
    }

    void Start()
    {
        Instance = this;
        lifeBar = FindFirstObjectByType<LifeBar>(FindObjectsInactive.Include);
        actionManager = GetComponent<StageActionManager>();
        var prefLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        

        currentLevel = prefLevel;
        livesRemaining = maxLives;
        actionManager.SetActions(StageDefinitions.GetLevelDefinition(currentLevel));
        actionManager.BeginStage();

        UpdateBackgroundMusic(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBackgroundMusic(int level)
    {
        var backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        AudioClip newLevelMusic = GetMusicClipForLevel(level);
        if (backgroundMusic != null && newLevelMusic != null)
        {
            backgroundMusic.clip = newLevelMusic;
            backgroundMusic.Play();
        }
    }
}
