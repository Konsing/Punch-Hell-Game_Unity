using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointObject : MonoBehaviour, IWaypoint
{
    public float moveToSpeed;
    public float timeStationary;

    public float MoveToSpeed { get => moveToSpeed; }
    public float TimeStationary { get => timeStationary; }
    public Vector3 Position { get => gameObject.transform.position; }
}

public class Waypoint : IWaypoint
{
    public float MoveToSpeed { get; set; }
    public float TimeStationary { get; set; }
    public Vector3 Position { get; set; }

    public Waypoint(float moveToSpeed, Vector3 position, float timeStationary)
    {
        MoveToSpeed = moveToSpeed;
        Position = position;
        TimeStationary = timeStationary;
    }

    public static Waypoint FromCameraPercent(float moveToSpeed, float xp, float yp, float z = 0, float timeStationary = 0)
    {
        Bounds camBounds = Camera.main.OrthographicBounds();
        float x = camBounds.min.x + (camBounds.max.x - camBounds.min.x) * xp / 100.0f;
        float y = camBounds.min.y + (camBounds.max.y - camBounds.min.y) * yp / 100.0f;

        Debug.Log($"Waypoint: {x}, {y}; Camera Bounds: [{camBounds.min}], [{camBounds.max}]");
        return new Waypoint(moveToSpeed, new Vector3(x, y, z), timeStationary);
    }
}