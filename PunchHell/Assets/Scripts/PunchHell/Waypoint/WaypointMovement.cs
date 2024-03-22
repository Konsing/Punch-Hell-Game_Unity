using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField]
    private WaypointObject[] _editorWaypoints = null;
    private IWaypoint[] _scriptWaypoint = null;
    private IWaypoint[] waypointList { get => _scriptWaypoint ?? _editorWaypoints; }

    private int waypointIndex = 0;
    private float timeStationary = 0.0f;

    public void SetWaypoints(IWaypoint[] waypoints) => _scriptWaypoint = waypoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointList == null || waypointList.Length == 0)
            return;

        Vector3 position = transform.position;
        Vector3 nextWaypoint = waypointList[waypointIndex].Position;

        if (Vector3.Distance(position, nextWaypoint) < 0.01f)
        {
            timeStationary += Time.deltaTime;

            if (timeStationary > waypointList[waypointIndex].TimeStationary)
            {
                timeStationary = 0.0f;
                waypointIndex = (waypointIndex + 1) % waypointList.Length;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(position, nextWaypoint, waypointList[waypointIndex].MoveToSpeed * Time.deltaTime);
        }
    }
}