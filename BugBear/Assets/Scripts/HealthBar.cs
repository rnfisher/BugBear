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
        [HideInInspector] public float maxHealth = 1f;
        [HideInInspector] public float currentHealth;
        public float healthDepletionSpeed = 0.005f; //Amount that the health declines
        public float counterTimerMax = 0.1f;
        public Slider healthBar;
        private float previousHealthDivided;
        private float newHealthDivided;
        private float healthGainCheck;
        private float newHealthGainAmount;

        private void Awake()
        {
            instance = this;
        }
        
        private void Start()
        {
            counterTimer = counterTimerMax;
            currentHealth = maxHealth;
            healthBar.value = maxHealth;
        }

        private void Update()
        {
            counterTimer -= Time.fixedDeltaTime;
            if (counterTimer <= 0 && currentHealth >= 0)
            {
                TakeDamage(healthDepletionSpeed);
                counterTimer = counterTimerMax;
            }

            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
                GainHealth(0.2f);
            }
        }

        public void TakeDamage(float damage)
        {
            previousHealthDivided = currentHealth / maxHealth;
            currentHealth -= damage;
            newHealthDivided = currentHealth / maxHealth;
            healthBar.value = currentHealth;

            if (healthBar.value == 0)
            {
                Debug.Log("You Died!");
                //FindObjectOfType<CanvasManager>().GameOver();
            }

            healthBar.value = Mathf.Lerp(previousHealthDivided, newHealthDivided, 0.1f);
        }

        public void GainHealth(float gain)
        {
            // Checks to see if the amount depleted on the health bar is smaller than the gain amount and changes the amount accordingly
            healthGainCheck = maxHealth - currentHealth;

            if (healthBar.value < maxHealth)
            {
                if (healthGainCheck <= gain)
                {
                    newHealthGainAmount = gain - healthGainCheck;
                    currentHealth += newHealthGainAmount;
                    Debug.Log("newHealthGainAmount: " + newHealthGainAmount);
                }
                else
                {
                    currentHealth += gain;
                    Debug.Log("currentHealth: " + currentHealth);
                }
                //currentHealth += gain;
                healthBar.value = currentHealth;
                
            }
        }
    }
}

