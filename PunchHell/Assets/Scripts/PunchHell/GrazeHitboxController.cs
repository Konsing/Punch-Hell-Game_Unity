using DanmakU;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeHitboxController : MonoBehaviour
{
    private DanmakuCollider danmakuCollider;

    void Start()
    {
        danmakuCollider = gameObject.AddComponent<DanmakuCollider>();
        danmakuCollider.OnDanmakuCollision += OnDanmakuCollision;
    }

    void OnDanmakuCollision(DanmakuCollisionList collisions)
    {
        foreach (var collision in collisions)
            GetComponentInParent<PlayerController>().OnDanmakuGraze();
    }
}
