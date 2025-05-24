using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        Debug.Log($"[PlayerHealth] TakeDamage appelé avec {amount}");
        health -= amount;
        Debug.Log($"[PlayerHealth] Nouvelle santé : {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");
        // ... logique de mort ...
    }
}

