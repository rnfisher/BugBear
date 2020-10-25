using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class HealthBar : MonoBehaviour
    {
        public static HealthBar instance;
        private float counterTimer;
        public static float maxHealth;
        public static float currentHealth;
        public float updateAmountHealth = 1; //Amount that the health declines
        public float counterTimerMax = 0.2f;
        public Slider healthBar;

        private void Awake()
        {
            instance = this;
        }

        private void FixedUpdate()
        {
            counterTimer -= Time.fixedDeltaTime;
            if (counterTimer <= 0)
            {
                TakeDamage(updateAmountHealth);
                counterTimer = counterTimerMax;

            }
        }

        private void LateStart()
        {
            currentHealth = maxHealth;
            healthBar.value = maxHealth;
            counterTimer = counterTimerMax;
        }

        public void SetMaxHealth(int health)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }

        public void SetHealth(int health)
        {
            healthBar.value = health;
        }

        public void TakeDamage(float damage)
        {
                currentHealth -= damage;
                healthBar.value = currentHealth; 
        }

        public void GainHealth(float health)
        {
            if (healthBar.value < maxHealth)
            {
                currentHealth += health;
                healthBar.value = currentHealth;
                Debug.Log(healthBar.value);
            }
        }
    }
}

