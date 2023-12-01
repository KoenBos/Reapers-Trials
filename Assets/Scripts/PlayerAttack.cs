using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackCollider;

    public int damage = 0;
    public Slider delaySlider;
    public float attackDelay = 0.0f;
    private float attackTimer = 0.0f;
    public float attackRange = 0.0f;
    public int direction = 0;
    public Animator animator;

    private Collider2D attackCollider;

    void Start()
    {
        AttackCollider.SetActive(false);

        attackCollider = AttackCollider.GetComponent<Collider2D>();
    }

void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Attack();
    }
    // Update the attack timer
    attackTimer += Time.deltaTime;
    if (attackTimer < attackDelay)
    {
        delaySlider.value = attackDelay - attackTimer;
    }
    else
    {
        delaySlider.value = 0.0f;
    }
}


    //disable the attack collider after 0.1 seconds
    IEnumerator DisableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        AttackCollider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthManager enemyHealth = collision.GetComponent<HealthManager>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }
    }

    public void Attack()
    {
    if (attackTimer > attackDelay)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Calculate the difference between the mouse position and the character's position
        Vector3 diff = mousePosition - transform.position;
        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            // If the absolute difference in X is greater than Y, it's a horizontal movement
            if (diff.x > 0)
            {
                // Attack right
                AttackCollider.transform.position = new Vector3(transform.position.x + 2.3f, transform.position.y + 2.0f, transform.position.z);
                AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetTrigger("AttackRight");
            }
            else
            {
                // Attack left
                AttackCollider.transform.position = new Vector3(transform.position.x - 2.3f, transform.position.y + 2.0f, transform.position.z);
                AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 180);
                animator.SetTrigger("AttackLeft");
            }
        }
        else
        {
            // If the absolute difference in Y is greater than X, it's a vertical movement
            if (diff.y > 0)
            {
                // Attack up
                AttackCollider.transform.position = new Vector3(transform.position.x, transform.position.y + 6.3f, transform.position.z);
                AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 90);
                animator.SetTrigger("AttackUp");
            }
            else
            {
                // Attack down
                AttackCollider.transform.position = new Vector3(transform.position.x, transform.position.y - 3.3f, transform.position.z);
                AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 270);
                animator.SetTrigger("AttackDown");
            }
        }
        AttackCollider.SetActive(true);
        StartCoroutine(DisableCollider());
        attackTimer = 0.0f;

        AttackCollider.transform.localScale = new Vector3(attackRange, attackRange, 1.0f);
    }
    }
}
