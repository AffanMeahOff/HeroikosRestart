using UnityEngine;

public class Enigme3IO1 : MonoBehaviour
{
    public string EnemyName;

    [SerializeField] Enigme3Waves enigme3Waves;
    private HealthBarEnemy healthBar;
    private Rigidbody rigid;
    public bool playerinarea;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
        rigid = GetComponentInChildren<Rigidbody>();
        rigid.useGravity = true;
    }

    public string GetEnemyName()
    {
        return EnemyName;
    }
    /*
    void OnMouseDown()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerinarea && healthBar != null)
        {
            healthBar.TakeDamage(20f);
        }
    }*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerinarea && healthBar != null)
        {
            healthBar.TakeDamage(20f);
        }
        if (healthBar.IsDead)
        {
            enigme3Waves.beaten = 1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerinarea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerinarea = false;
        }    
    }
}
