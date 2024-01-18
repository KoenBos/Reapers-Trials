using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 200f;

    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // if (Input.GetKey(KeyCode.W))
        // {
        //     animator.SetFloat("IdleDirection", 0);
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     animator.SetFloat("IdleDirection", 1);
        // }
        // else if (Input.GetKey(KeyCode.A))
        // {
        //     animator.SetFloat("IdleDirection", 2);
        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     animator.SetFloat("IdleDirection", 3);
        // }
        //on mouse click, attack
        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle >= -45 && angle < 45)
        {
            animator.SetFloat("IdleDirection", 3); // Right
            animator.SetFloat("MoveDirection", 3); // Right

        }
        else if (angle >= 45 && angle < 135)
        {
            animator.SetFloat("IdleDirection", 0); // Up
            animator.SetFloat("MoveDirection", 0);

        }
        else if (angle >= -135 && angle < -45)
        {
            animator.SetFloat("IdleDirection", 1); // Down
            animator.SetFloat("MoveDirection", 1);

        }
        else
        {
            animator.SetFloat("IdleDirection", 2); // Left
            animator.SetFloat("MoveDirection", 2);

        }
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveDirection * playerSpeed * Time.deltaTime;

        // animator.SetFloat("Horizontal", moveX);
        // animator.SetFloat("Vertical", moveY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        
    }
}
