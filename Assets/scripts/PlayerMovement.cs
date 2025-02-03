using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from player
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        // Normalize movement to prevent faster diagonal movement
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        // Apply movement to Rigidbody2D
        rb.linearVelocity = movement * moveSpeed;
    }
}
