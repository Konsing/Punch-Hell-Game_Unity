using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static class StageDefinitions
{
    public static List<StageAction> GetLevelDefinition(int level) => level switch
    {
        1 => GetLevel1(),
        2 => GetLevel2(),
        _ => null,
    };

    private static List<StageAction> GetLevel1()
    {
        var enemyAWaypoints = new List<IWaypoint>
        {
                Waypoint.FromCameraPercent(250, 90.0f, 90.0f),
                Waypoint.FromCameraPercent(250, 75.0f, 90.0f),
                Waypoint.FromCameraPercent(250, 40.0f, 70.0f),
                Waypoint.FromCameraPercent(250, 20.0f, 60.0f),
                Waypoint.FromCameraPercent(250, 50.0f, 65.0f)
        };

        return new List<StageAction>
        {
                new StageActionSpawn("Enemies/EnemyBase", new Vector3(640, 720, 0)),
                new StageActionDialogue("Player", "I am so sick and tired of this shit"),
                new StageActionDialogue("Enemy", "Me too dude"),
                new StageActionDelay(5.0f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyA", new Vector3(1100, 1100, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionWaitForClear()
        };
    }

    private static List<StageAction> GetLevel2()
{
    var enemyAWaypoints = new List<IWaypoint>
        {
                Waypoint.FromCameraPercent(250, 85.0f, 75.0f),
                Waypoint.FromCameraPercent(250, 65.0f, 85.0f),
                Waypoint.FromCameraPercent(250, 45.0f, 55.0f),
                Waypoint.FromCameraPercent(250, 25.0f, 65.0f),
                Waypoint.FromCameraPercent(250, 50.0f, 80.0f)
        };
    
    return new List<StageAction>
    {
                new StageActionSpawn("Enemies/EnemyBase2", new Vector3(640, 720, 0)),
                new StageActionDialogue("Player", "Why do I have to do this, man?"),
                new StageActionDialogue("Enemy", "Hold the L"),
                new StageActionDelay(5.0f),
                new StageActionSpawn("Enemies/EnemyB", new Vector3(800, 800, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyB", new Vector3(600, 800, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyB", new Vector3(500, 900, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionSpawn("Enemies/EnemyB", new Vector3(250, 300, 0), enemyAWaypoints),
                new StageActionDelay(2.5f),
                new StageActionWaitForClear()
    };
}
}
