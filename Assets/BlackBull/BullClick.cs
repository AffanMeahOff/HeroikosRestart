using UnityEngine;

public class BullClick : MonoBehaviour
{
    private HealthBarAI healthBar;
    public Transform playerTransform;
    public float minDistance = 7f;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarAI>();

        if (playerTransform == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void OnMouseDown()
    {
        if (healthBar == null) return;
        if (playerTransform == null)
        {
            Debug.LogWarning("Référence au joueur manquante.");
            return;
        }

        float distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance > minDistance)
        {
            Debug.Log("Trop loin pour infliger des dégâts. Distance actuelle : " + distance);
            return;
        }

        healthBar.TakeDamage(70f);
    }
}
