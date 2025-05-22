using UnityEngine;

public class BossController : MonoBehaviour
{
    public float health = 100f;
    public GameObject player;
    public GameObject endGameCanvas;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void AttackPlayer()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(7);
            }
        }
    }

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 3f)
        {
            AttackPlayer();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        Invoke("ShowEndScreen", 4f);
    }

    void ShowEndScreen()
    {
        endGameCanvas.SetActive(true);
    }
}
