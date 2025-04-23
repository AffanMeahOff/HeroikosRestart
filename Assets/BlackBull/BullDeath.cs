using UnityEngine;

public class BullDeath : MonoBehaviour
{
    private HealthBarAI healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarAI>();
        if (healthBar != null)
        {
            healthBar.OnDeath += Die;
        }
    }

    void Die()
    {
        Debug.Log("Bull est mort !");
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (healthBar != null)
        {
            healthBar.OnDeath -= Die;
        }
    }
}

