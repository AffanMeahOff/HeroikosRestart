using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private Image healthBarImage;
    private float currentHealth = 60f;
    private float maxHealth = 60f;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            OnDeath?.Invoke();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
            healthBarImage.fillAmount = currentHealth / maxHealth;
    }
}


