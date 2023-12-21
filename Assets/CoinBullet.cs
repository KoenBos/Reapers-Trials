using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Do nothing if collides with an enemy tagged gameobject
            return;
        }
        else if (collision.gameObject.CompareTag("Player"))
        { 
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(20);
            Destroy(gameObject);
        }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}