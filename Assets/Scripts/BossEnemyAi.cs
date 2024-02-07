using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BossEnemyAi : MonoBehaviour
{
    public Transform target;
    public float activationDistance = 10f; // Distance at which the boss activates
    public float speed = 200;
    public float nextWaypointDistance = 3f;
    public float jumpAttackCooldown = 5f;
    public float jumpHeight = 10f;
    public float jumpSpeed = 5f;

    [SerializeField] private GameObject miniSlimePrefab; // Prefab for the mini slime
    [SerializeField] private bool isBoss = true;

    public int damage = 50;
    private bool isActive = false; // New flag to check if the boss is active
    private bool isJumping = false;
    private float lastJumpTime = 0f;
    private float lastSpawnTime = 0f; // Timer for spawning mini slimes
    private float spawnInterval = 10f; // Interval for spawning mini slimes
    private bool isSecondStage = false;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;
    Collider2D bossCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        bossCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!isActive && Vector2.Distance(transform.position, target.position) <= activationDistance)
        {
            ActivateBoss();
        }

        if (!isActive)
        {
            return;
        }

        if (Time.time - lastJumpTime > jumpAttackCooldown - 0.3f)
            animator.SetTrigger("Charging");

        if (Time.time - lastJumpTime > jumpAttackCooldown)
            StartCoroutine(JumpAttack());

        if (Time.time - lastSpawnTime > spawnInterval)
        {
            StartCoroutine(SpawnMiniSlime());
            lastSpawnTime = Time.time;
        }

        if (isSecondStage == false && GetComponent<HealthManager>().currentHealth <= GetComponent<HealthManager>().maxHealth / 2)
        {
            secondStage();
            isSecondStage = true;
        }
    }

    void FixedUpdate()
    {
        if (!isActive || path == null || isJumping)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
            return;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
            currentWaypoint++;
    }

    void ActivateBoss()
    {
        isActive = true;
        UpdatePath();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (!isJumping && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            rb.AddForce(-transform.up * 300f);
        }
    }

    void secondStage()
    {
        speed = 20000;
        jumpAttackCooldown = 2f;
        jumpSpeed = 1.5f;
    }

    IEnumerator JumpAttack()
    {
        lastJumpTime = Time.time;
        isJumping = true;
        spriteRenderer.sortingOrder = 10;
        bossCollider.enabled = false;
        animator.SetTrigger("Jump");

        Vector3 start = transform.position;
        Vector3 end = target.position;

        float jumpTime = 0;

        while (jumpTime < 1f)
        {
            jumpTime += Time.deltaTime * jumpSpeed;
            float height = Mathf.Sin(Mathf.PI * jumpTime) * jumpHeight;
            transform.position = Vector3.Lerp(start, end, jumpTime) + Vector3.up * height;
            yield return null;
        }

        isJumping = false;
        bossCollider.enabled = true;
        animator.SetTrigger("Land");
        spriteRenderer.sortingOrder = 0;

        if (isBoss)
        {
            // Assuming CinemachineShake.Instance.ShakeCamera exists in your project
            CinemachineShake.Instance.ShakeCamera(20.0f, 0.3f);
        }
    }

    IEnumerator SpawnMiniSlime()
    {
        if (miniSlimePrefab != null)
        {
            Instantiate(miniSlimePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(miniSlimePrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
            Instantiate(miniSlimePrefab, transform.position, Quaternion.identity);
        }
    }
}
