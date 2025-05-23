using UnityEngine;

public class MinotaurHorns : MonoBehaviour
{
    public bool IsDead;
    private float currentHealth;
    public float maxHealth = 60f;
    public bool OnHorns;
    void Start()
    {
        currentHealth = maxHealth;
        IsDead = false;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0f)
        {
            IsDead = true;
        }
    }
    public void Die()
    {
        if (IsDead)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnHorns = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnHorns = false;
        }
    }
}