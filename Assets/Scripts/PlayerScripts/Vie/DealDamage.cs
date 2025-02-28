using UnityEngine;

public class DealDamage : MonoBehaviour 
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerStats = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }
    }
}