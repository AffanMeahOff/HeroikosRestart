using UnityEngine;

public class BossClick : MonoBehaviour
{
    private BossController bossController;
    private HealthBarAI healthBar;

    public Transform playerTransform;
    public float minDistance = 15f;

    void Start()
    {
        bossController = GetComponent<BossController>();
        healthBar = GetComponentInChildren<HealthBarAI>();

        if (playerTransform == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void OnMouseDown()
    {
        if (bossController == null) return;

        if (playerTransform == null)
        {
            Debug.LogWarning("Pas de référence au joueur.");
            return;
        }

        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance > minDistance)
        {
            Debug.Log("Trop loin pour attaquer. Distance actuelle : " + distance);
            return;
        }

        int damageAmount = 20;
        bossController.TakeDamage(damageAmount);

        if (healthBar != null)
        {
            healthBar.TakeDamage(damageAmount);
        }
    }
}
