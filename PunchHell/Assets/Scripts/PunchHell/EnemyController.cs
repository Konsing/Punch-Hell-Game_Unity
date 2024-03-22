using DanmakU;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private DanmakuCollider danmakuCollider;
    private SpriteRenderer sprite;
    private Coroutine flashCoroutine;
    private ParticleSystem explosionParticles;

    [SerializeField]
    private GameObject powerPrefab;

    [SerializeField]
    private GameObject pointPrefab;

    [SerializeField]
    private GameObject bulletPointPrefab;

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private int scoreValue = 10;

    [SerializeField]
    private bool hasPointDrop = true;

    [SerializeField]
    private bool hasPowerDrop = false;

    // Start is called before the first frame update
    void Start()
    {
        danmakuCollider = gameObject.AddComponent<DanmakuCollider>();
        danmakuCollider.OnDanmakuCollision += OnDanmakuCollide;

        sprite = GetComponent<SpriteRenderer>();
        explosionParticles = GetComponent<ParticleSystem>();
    }

    IEnumerator FlashSpriteCoroutine()
    {
        var oldColor = sprite.color;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.1f);

        for (int i = 0; i < 2; i++)
            yield return new WaitForEndOfFrame();

        sprite.color = oldColor;

        yield return new WaitForEndOfFrame();

        flashCoroutine = null;
    }

    void FlashSprite()
    {
        if (flashCoroutine == null && health > 0)
            flashCoroutine = StartCoroutine(FlashSpriteCoroutine());
    }

    void TakeDamage(int damage)
    {
        FlashSprite();

        if (health <= 0)
            return;

        health -= damage;

        if (health <= 0)
            Explode();
    }

    void Explode()
    {
        StageManager.Instance.AddScore(scoreValue);
        sprite.enabled = false;
        explosionParticles.Play();

        var danmakuBehavior = GetComponentInChildren<DanmakuBehaviour>();
        var bulletPositions = danmakuBehavior.GetDanmakuPositions();

        foreach (var position in bulletPositions)
        {
            Instantiate(bulletPointPrefab, position, Quaternion.identity);
        }

        Destroy(danmakuBehavior.gameObject);
        Destroy(gameObject, explosionParticles.main.duration);

        if (hasPointDrop)
            Instantiate(pointPrefab, transform.position, Quaternion.identity);

        if (hasPowerDrop)
            Instantiate(powerPrefab, transform.position, Quaternion.identity);
    }

    void OnDanmakuCollide(DanmakuCollisionList collisions)
    {
        foreach (var bullet in collisions)
        {
            if (PlayerController.Instance.IsPlayerBullet(bullet.Danmaku))
            {
                bullet.Danmaku.Destroy();
                TakeDamage(10);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
