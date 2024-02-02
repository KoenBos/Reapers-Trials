using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HealthManager enemyHealth = collision.GetComponent<HealthManager>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);
            }
        }
    }
}
