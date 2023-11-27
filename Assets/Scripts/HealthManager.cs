using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private bool DropLoot = false;
    [SerializeField] private GameObject LootPrefab;


    

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        //audioManager = FindObjectOfType<AudioManager>();
    }

    public void TakeDamage(int damage)
    {
       // audioManager.PlaySFX("Enemy_Hit");
        //audioManager.PlaySFX("Enemy_Hit2");
        slider.gameObject.SetActive(true);
        currentHealth -= damage;
        slider.value = currentHealth;

        //tijdelijk
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3 enemyPosition = transform.position;
        Vector3 direction = enemyPosition - playerPosition;
        direction.Normalize();
        GetComponent<Rigidbody2D>().AddForce(direction * 1000);

        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
    
        if (currentHealth <= 0)
        {
            if (DropLoot)
            {
                Instantiate(LootPrefab, transform.position, Quaternion.identity);
            }
            //audioManager.PlaySFX("Enemy_Death");
            Destroy(gameObject);
        }
    }
}
