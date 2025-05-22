using UnityEngine;

public class Enigme3IO1 : MonoBehaviour
{
    public bool playerinarea;
    public string EnemyName;

    [SerializeField] Enigme3Waves enigme3Waves;
    private HealthBarEnemy healthBar;
    private Rigidbody rigid;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
        rigid = GetComponentInChildren<Rigidbody>();
        rigid.useGravity = true;
    }

    void OnMouseDown()
    {
        if (healthBar != null)
        {
            healthBar.TakeDamage(20f);
        }
    }
    public string GetEnemyName()
    {
        return EnemyName;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerinarea)
        {
            enigme3Waves.beaten += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            playerinarea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
            playerinarea = false;
        }    
    }
}
