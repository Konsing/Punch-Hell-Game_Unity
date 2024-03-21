using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public static class StageDefinitions
{
    public static List<StageAction> GetLevelDefinition(int level)
    {
        return level switch
        {
            1 => GetLevel1(),
            _ => null,
        };
    }

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
}
