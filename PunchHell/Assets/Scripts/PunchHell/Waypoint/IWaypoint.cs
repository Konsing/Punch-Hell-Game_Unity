using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IWaypoint
{
    float TimeStationary { get; }
    float MoveToSpeed { get; }
    Vector3 Position { get; }
}
