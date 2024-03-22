using System.Collections;
using System.Collections.Generic;
using DanmakU;
using DanmakU.Fireables;
using UnityEngine;


public class PlayerDanmakuEmitter : DanmakuBehaviour
{
    public DanmakuPrefab DanmakuType;
    public Range Speed = 5f;
    public Color Color = Color.white;
    public Range FireRate = 5;

    private float fireCooldown;
    private bool isFiring = false;
    private DanmakuConfig config;
    private IFireable fireable;
    private DanmakuPool bulletPool;
    
    public bool IsEmitter(Danmaku bullet)
    {
        return bullet.Pool == bulletPool;
    }

    public void EnableFiring()
    {
        isFiring = true;
    }

    public void DisableFiring()
    {
        fireCooldown = 0;
        isFiring = false;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (DanmakuType == null)
        {
            Debug.LogWarning($"Emitter doesn't have a valid DanmakuPrefab", this);
            return;
        }

        var danmakuSet = CreateSet(DanmakuType);
        bulletPool = danmakuSet.Pool;
        fireable = danmakuSet;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!isFiring || fireable == null)
            return;

        fireCooldown -= Time.deltaTime;

        if (fireCooldown < 0)
        {
            config = new DanmakuConfig
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles.z * Mathf.Deg2Rad,
                Speed = Speed,
                AngularSpeed = 0,
                Color = Color
            };

            fireable.Fire(config);

            fireCooldown = 1f / FireRate.GetValue();
        }
    }

}