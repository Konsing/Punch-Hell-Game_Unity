using DanmakU;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    [SerializeField]
    private float moveSpeed = 360.0f;
    [SerializeField]
    private float slowMoveSpeed = 160.0f;
    [SerializeField]
    private float rollMoveSpeed = 420f;
    [SerializeField]
    private float grazeCooldown = 0.02f;
    [SerializeField]
    private float invincibilityTimeAfterDeath = 2.0f;
    [SerializeField]
    private float rollTimeMax = 1.5f;
    [SerializeField]
    private int powerAddedByPowerup = 10;
    [SerializeField]
    private int scoreAddedByDrop = 20;
    [SerializeField]
    private int scoreAddedByDestroyedBullets = 1;
    [SerializeField]
    private int scoreAddedByGraze = 1;

    private PlayerDanmakuEmitter[] bulletEmitters;
    private SpriteRenderer[] sprites;
    private Transform rollSprite;
    private Coroutine flashSpriteCoroutine;
    private float invincibilityRemaining = 0.0f;
    private float lastGraze = 0.0f;
    private float rollTimeRemaining = 0.0f;

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
        if (flashSpriteCoroutine == null && gameObject.activeInHierarchy)
            flashSpriteCoroutine = StartCoroutine(FlashSpriteCoroutine());
    }

    public bool IsPlayerBullet(Danmaku bullet)
    {
        foreach (var emitter in bulletEmitters)
            if (emitter.IsEmitter(bullet))
                return true;

        return false;
    }

    public void SetTurretsEnabled(int count)
    {
        for (int i = 1; i <= 3; i++)
            transform.Find($"Turret {i}").gameObject.SetActive(count >= i);
    }

    void Start()
    {
        Instance = this;

        rollSprite = transform.Find("RollPipe");
        bulletEmitters = GetComponentsInChildren<PlayerDanmakuEmitter>(true);
        sprites = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !StageManager.Instance.DialogueActive)
            StageManager.Instance.Paused = !StageManager.Instance.Paused;

        if (Input.GetKeyDown(KeyCode.Space) && StageManager.Instance.RollLevel >= 100)
        {
            StageManager.Instance.AddRoll(-StageManager.Instance.RollLevel);
            rollTimeRemaining = rollTimeMax;
        }

        if (rollTimeRemaining <= 0.0f)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rollSprite.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log((rollTimeMax - rollTimeRemaining) / rollTimeMax);
            transform.Rotate(new Vector3(0, 0, 360 / rollTimeMax * Time.deltaTime));
            rollSprite.gameObject.SetActive(true);
        }

        rollTimeRemaining = Mathf.Max(0.0f, rollTimeRemaining -= Time.deltaTime);
        invincibilityRemaining = Mathf.Max(0.0f, invincibilityRemaining -= Time.deltaTime);

        var slowMove = Input.GetButton("Fire2");

        transform.Find("Hitbox").GetComponent<SpriteRenderer>().enabled = slowMove;

        var speed = slowMove ? slowMoveSpeed : (rollTimeRemaining > 0.0f ? rollMoveSpeed : moveSpeed);

        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        gameObject.transform.position += movement * speed * Time.deltaTime;

        var cameraBounds = Camera.main.OrthographicBounds();

        gameObject.transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(transform.position.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z);

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
        StageManager.Instance.LivesRemaining -= 1;
        invincibilityRemaining = invincibilityTimeAfterDeath;
    }

    public void OnDanmakuCollision(Danmaku bullet)
    {
        if (invincibilityRemaining > 0.0f || rollTimeRemaining > 0.0f)
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
        StageManager.Instance.AddScore(scoreAddedByGraze);
        StageManager.Instance.AddRoll(scoreAddedByGraze);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            StageManager.Instance.AddPower(powerAddedByPowerup);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Point"))
        {
            StageManager.Instance.AddScore(scoreAddedByDrop);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet Point"))
        {
            StageManager.Instance.AddScore(scoreAddedByDestroyedBullets);
            Destroy(other.gameObject);
        }
    }
}