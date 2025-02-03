using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRadius = 5f;
    public Transform player;
    public int health = 3;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 randomDirection;
    private float changeDirectionTime = 2f;
    private float timeSinceLastChange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDirection();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Follow player
            movement = (player.position - transform.position).normalized;
        }
        else
        {
            // Random movement when idle
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= changeDirectionTime)
            {
                ChooseRandomDirection();
                timeSinceLastChange = 0f;
            }
            movement = randomDirection;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void ChooseRandomDirection()
    {
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}