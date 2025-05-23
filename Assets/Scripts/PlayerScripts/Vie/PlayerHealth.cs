using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Le joueur prend " + amount + " dégâts. Santé restante : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Ajoute ici la logique de mort : désactivation, anim, game over, etc.
    }
}

