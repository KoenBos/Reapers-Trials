using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject AttackCollider;

    private Collider2D attackCollider;

    void Start()
    {
        AttackCollider.SetActive(false);

        attackCollider = AttackCollider.GetComponent<Collider2D>();
    }

void Update()
{
    // Base on the center of the screen to determine the direction up, down, left and right of the attack based on the mouse position
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
            AttackCollider.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            // Attack left
            AttackCollider.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
            AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
    else
    {
        // If the absolute difference in Y is greater than X, it's a vertical movement
        if (diff.y > 0)
        {
            // Attack up
            AttackCollider.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            // Attack down
            AttackCollider.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            AttackCollider.transform.rotation = Quaternion.Euler(0, 0, 270);
        }
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
                enemyHealth.TakeDamage(10);
            }
        }
    }
}
