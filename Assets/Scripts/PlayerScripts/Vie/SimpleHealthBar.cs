using UnityEngine;
using UnityEngine.UI;

public class SimpleHealthBar : MonoBehaviour
{
    public Slider healthBar;
    PlayerHealth playerHealth;

    void Start ()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {

        healthBar.value = playerHealth.health;
    }

}
