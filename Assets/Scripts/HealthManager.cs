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
    //public Animator alienAnimator;

    //private AudioManager audioManager;



    

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
        //alienAnimator.SetTrigger("hit");
        if (currentHealth <= 0)
        {
            // Die
            //audioManager.PlaySFX("Alien_Scream");
            Destroy(gameObject);
        }
    }
}
