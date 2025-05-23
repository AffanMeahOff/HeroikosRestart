using UnityEngine;

public class BossController : MonoBehaviour
{
    public float health = 100;
    public GameObject player;
    public GameObject endGameCanvas;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }



    void Update()
    {
        if (isDead) return;
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject);
        Invoke("ShowEndScreen", 4f);
    }

    void ShowEndScreen()
    {
        endGameCanvas.SetActive(true);
    }
}
