using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{

    [SerializeField] private Image healthBarImage;
    public bool IsDead;
    private float currentHealth;
    public float maxHealth = 60f;
    void Start()
    {
        currentHealth = maxHealth;
        IsDead = false;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            IsDead = true;
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}


