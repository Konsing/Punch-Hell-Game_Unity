using DanmakU;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
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
            GetComponentInParent<PlayerController>().OnDanmakuCollision(collision.Danmaku);
    }

    private void OnDrawGizmos()
    { 
        var collider = GetComponent<CircleCollider2D>();
        Gizmos.DrawWireSphere(collider.transform.position, collider.radius);
    }
}
