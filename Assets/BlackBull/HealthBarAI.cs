using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAI : MonoBehaviour
{
    public event Action OnDeath;

    [SerializeField] private Image healthBarImage;
    private float currentHealth = 100f;
    private float maxHealth = 100f;

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


