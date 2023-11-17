using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    private float invincibilityDuration;
    private Animator animator;
    //private AudioManager audioManager;

    private void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    private void Update()
    {
        // Reduce the invincibility timer if active
        if (isInvincible)
        {
            invincibilityDuration -= Time.deltaTime;
            if (invincibilityDuration <= 0.0f)
            {
                animator.SetBool("IsHit", false);
                isInvincible = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            //audioManager.PlaySFX("Player_Hit");
            currentHealth -= damage;
            slider.value = currentHealth;
            animator.SetBool("IsHit", true);
            
            if (currentHealth <= 0)
            {
                // Die
            }

            // Apply invincibility
            isInvincible = true;
            invincibilityDuration = 5.0f;
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        slider.value = currentHealth;
    }
}