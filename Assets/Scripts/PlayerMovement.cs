using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 200f;

    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("IdleDirection", 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat("IdleDirection", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("IdleDirection", 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("IdleDirection", 3);
        }
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveDirection * playerSpeed * Time.deltaTime;

        animator.SetFloat("Horizontal", moveX);
        animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        
    }
}
