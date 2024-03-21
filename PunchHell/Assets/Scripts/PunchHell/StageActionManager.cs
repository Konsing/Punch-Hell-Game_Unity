using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StageAction
{

}

public class StageActionDelay : StageAction
{
    public float delay;

    public StageActionDelay(float delay)
    {
        this.delay = delay;
    }
}

public class StageActionWaitForClear : StageAction
{

}

public class StageActionSpawn : StageAction
{
    public GameObject enemyPrefab;
    public Vector3 position;
    public List<IWaypoint> waypoints;

    public StageActionSpawn(GameObject enemyPrefab, Vector3 position, List<IWaypoint> waypoints = null)
    {
        this.enemyPrefab = enemyPrefab;
        this.position = position;
        this.waypoints = waypoints;
    }

    public StageActionSpawn(string prefabName, Vector3 position, List<IWaypoint> waypoints = null)
    {
        this.enemyPrefab = (GameObject)Resources.Load($"Prefabs/{prefabName}");
        this.position = position;
        this.waypoints = waypoints;
    }
}

public class StageActionDialogue : StageAction
{
    public string characterName;
    public string text;

    public StageActionDialogue(string characterName, string text)
    {
        this.characterName = characterName;
        this.text = text;
    }
}

public class StageActionManager : MonoBehaviour
{
    private List<StageAction> actions;
    private int currentAction = 0;

    IEnumerator ActionQueueCoroutine()
    {
        while (currentAction < actions.Count)
        {
            StageAction action = actions[currentAction];

            if (action is StageActionDelay delay)
            {
                yield return new WaitForSeconds(delay.delay);
            }

            if (action is StageActionWaitForClear)
            {
                while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
                    yield return new WaitForEndOfFrame();
            }

            if (action is StageActionDialogue dialogue)
            {
                StageManager.Instance.DialogueActive = true;
                var dialogueBox = GameObject.FindFirstObjectByType<DialogueBoxController>(FindObjectsInactive.Include);
                dialogueBox.SetName(dialogue.characterName);
                dialogueBox.SetText(dialogue.text);

                dialogueBox.SetVisible(true);
                yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

                dialogueBox.SetVisible(false);
                StageManager.Instance.DialogueActive = false;

                yield return new WaitForSeconds(0.1f);
            }

            if (action is StageActionSpawn spawn)
            {
                var enemy = Instantiate(spawn.enemyPrefab, spawn.position, Quaternion.identity);

                var waypoints = enemy.GetComponent<WaypointMovement>();
                if (spawn.waypoints != null && waypoints != null)
                    waypoints.SetWaypoints(spawn.waypoints.ToArray());
            }

            currentAction++;
        }
    }

    void Start()
    {
        
    }

    public void SetActions(List<StageAction> actions) => this.actions = actions;
    public void BeginStage()
    {
        StartCoroutine(ActionQueueCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}