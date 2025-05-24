using UnityEngine;

public class Enigme3IO1 : MonoBehaviour
{
    public string EnemyName;

    [SerializeField] Enigme3Waves enigme3Waves;
    private HealthBarEnemy healthBar;
    private bool playerinarea;

    public bool isType1;
    public bool isType2;
    public bool isType3;
    public bool isType4;
    public bool isMinotaur;
    private bool IsStun;
    private bool NoArmor;
    private bool NoHelmet;
    private MinotaurHorns Horns;
    private bool OnHorns;
    public GameObject Helmet = null;
    public GameObject Armor = null;
    private bool attacking;
    private int armorleft = 2;
    private GameObject player;
    private PlayerButtonScripts sword;
    private MouvementEnnemi move;

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
        player = GameObject.FindWithTag("Player");
        sword = player.GetComponent<PlayerButtonScripts>();
        move = GetComponent<MouvementEnnemi>();        
        IsStun = false;
    }

    public string GetEnemyName()
    {
        return EnemyName;
    }

    void Update()
    {
        attacking = move.attacking;
        if (sword.GetBlocking() && playerinarea && attacking)
        {
            move.Stun(5f);
            IsStun = move.isStunned;
        }
        if (armorleft == 0) NoArmor = true;
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerinarea && healthBar != null)
        {
            healthBar.TakeDamage(20f);
        }
        if (healthBar.IsDead)
        {
            enigme3Waves.beaten = 1;
            Destroy(gameObject);
            if (isMinotaur) enigme3Waves.enigme3Finished = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinarea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinarea = false;
        }
    }

}
