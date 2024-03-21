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
    private GameObject metricsCluster;
    private int currentAction = 0;
    private Coroutine queueProcessingCoroutine;

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

                var dialogueBox = FindFirstObjectByType<DialogueBoxController>(FindObjectsInactive.Include);
                dialogueBox.SetName(dialogue.characterName);
                dialogueBox.SetText(dialogue.text);
                dialogueBox.SetVisible(true);

                metricsCluster.SetActive(false);

                yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

                var isRemainingInDialogue = currentAction + 1 <= actions.Count - 1 && actions[currentAction + 1] is StageActionDialogue;

                if (!isRemainingInDialogue)
                {
                    dialogueBox.SetVisible(false);
                    metricsCluster.SetActive(true);
                }

                StageManager.Instance.DialogueActive = isRemainingInDialogue;

                yield return new WaitForSecondsRealtime(0.1f);
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

        queueProcessingCoroutine = null;
    }

    void Awake()
    {
        metricsCluster = GameObject.Find("Cluster");
    }

    public bool SetActions(List<StageAction> actions)
    {
        if (queueProcessingCoroutine == null)
        {
            this.actions = actions;
            return true;
        }

        return false;
    }

    public void StopStage()
    {
        StopCoroutine(queueProcessingCoroutine);
        queueProcessingCoroutine = null;
    }

    public void BeginStage()
    {
        if (queueProcessingCoroutine != null)
            return;

        queueProcessingCoroutine = StartCoroutine(ActionQueueCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
