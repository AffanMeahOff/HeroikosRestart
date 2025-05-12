using UnityEngine;

public class BullClick : MonoBehaviour
{
    private HealthBarAI healthBar;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarAI>();
    }

    void OnMouseDown()
    {
        if (healthBar != null)
        {
            healthBar.TakeDamage(20f);
        }
    }
}
