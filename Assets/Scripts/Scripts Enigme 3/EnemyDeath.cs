using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private HealthBarEnemy healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
        if (healthBar != null)
        {
            healthBar.OnDeath += Die;
        }
    }

    void Die()
    {
        Debug.Log("Cet Ennemi est mort !");
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

