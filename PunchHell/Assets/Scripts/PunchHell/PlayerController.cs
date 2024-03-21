using DanmakU;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField]
    private float moveSpeed = 256.0f;
    [SerializeField]
    private float slowMoveSpeed = 64.0f;
    [SerializeField]
    private float grazeCooldown = 0.05f;

    private PlayerDanmakuEmitter[] bulletEmitters;
    private float invincibilityRemaining = 0.0f;
    private float lastGraze = 0.0f;

    private Coroutine flashSpriteCoroutine;
    private SpriteRenderer[] sprites;

    IEnumerator FlashSpriteCoroutine()
    {
        var oldColor = sprites.Select(x => x.color).ToArray();

        for (int i = 0; i < 60; i++)
        {
            for (int j = 0; j < oldColor.Length; j++)
                sprites[j].color = new Color(oldColor[j].r, oldColor[j].g, oldColor[j].b, 0.1f);

            for (int j = 0; j < 2; j++)
                yield return new WaitForEndOfFrame();

            for (int j = 0; j < oldColor.Length; j++)
                sprites[j].color = oldColor[j];

            for (int j = 0; j < 2; j++)
                yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();

        flashSpriteCoroutine = null;
    }

    void FlashSprite()
    {
        if (flashSpriteCoroutine == null)
            flashSpriteCoroutine = StartCoroutine(FlashSpriteCoroutine());
    }

    public bool IsPlayerBullet(Danmaku bullet)
    {
        foreach (var emitter in bulletEmitters)
            if (emitter.IsEmitter(bullet))
                return true;

        return false;
    }

    void Start()
    {
        Instance = this;

        bulletEmitters = GetComponentsInChildren<PlayerDanmakuEmitter>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    void SetTurretsEnabled(int count)
    {
        for (int i = 1; i <= 3; i++)
            transform.Find($"Turret {i}").gameObject.SetActive(count >= i);
    }

    void Update()
    {
        invincibilityRemaining = Mathf.Max(0.0f, invincibilityRemaining -= Time.deltaTime);

        var slowMove = Input.GetButton("Fire2");

        transform.Find("Hitbox").GetComponent<SpriteRenderer>().enabled = slowMove;

        var speed = slowMove ? slowMoveSpeed : moveSpeed;

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        gameObject.transform.position += movement * speed * Time.deltaTime;

        var cameraBounds = Camera.main.OrthographicBounds();

        gameObject.transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(transform.position.y, cameraBounds.min.y, cameraBounds.max.y), transform.position.z);

        foreach (var emitter in bulletEmitters)
        {
            if (Input.GetButton("Fire1"))
                emitter.EnableFiring();
            else
                emitter.DisableFiring();
        }
    }

    void Die()
    {
        invincibilityRemaining = 2.0f;
    }

    public void OnDanmakuCollision(Danmaku bullet)
    {
        if (invincibilityRemaining > 0.0)
            return;

        bullet.Destroy();
        Die();
        FlashSprite();
    }

    public void OnDanmakuGraze()
    {
        lastGraze += Time.deltaTime;
        if (lastGraze < grazeCooldown)
            return;

        lastGraze = 0.0f;
        StageManager.Instance.AddScore(1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            StageManager.Instance.AddPower(5);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Point"))
        {
            StageManager.Instance.AddScore(20);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet Point"))
        {
            StageManager.Instance.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}