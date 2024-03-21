using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    private StageActionManager actionManager;

    private bool paused = false;
    private bool dialogueActive = false;

    public bool Paused 
    { 
        get => dialogueActive || paused; 
        set
        {
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

    void Start()
    {
        Instance = this;
        actionManager = GetComponent<StageActionManager>();

        var enemyAWaypoints = new List<IWaypoint>
        {
            Waypoint.FromCameraPercent(250, 90.0f, 90.0f),
            Waypoint.FromCameraPercent(250, 75.0f, 90.0f),
            Waypoint.FromCameraPercent(250, 40.0f, 70.0f),
            Waypoint.FromCameraPercent(250, 20.0f, 60.0f),
            Waypoint.FromCameraPercent(250, 50.0f, 65.0f)
        };

        actionManager.SetActions(new List<StageAction>
        {
            new StageActionDialogue("Player", "I am so sick and tired of this shit"),
            new StageActionDialogue("Enemy", "Me too dude"),
            new StageActionDelay(5.0f),
            new StageActionSpawn("EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
            new StageActionDelay(2.5f),
            new StageActionSpawn("EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
            new StageActionDelay(2.5f),
            new StageActionSpawn("EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
            new StageActionDelay(2.5f),
            new StageActionWaitForClear()
        });

        actionManager.BeginStage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
