using UnityEngine;

public class Enigme3IO1 : MonoBehaviour
{
    public string EnemyName;

    [SerializeField] Enigme3Waves enigme3Waves;
    private HealthBarEnemy healthBar;
    private Rigidbody rigid;
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

    void Start()
    {
        healthBar = GetComponentInChildren<HealthBarEnemy>();
        rigid = GetComponentInChildren<Rigidbody>();
        rigid.useGravity = true;
        IsStun = false;
        NoHelmet = false;
        if (isMinotaur)
        {
            Horns = GetComponentInChildren<MinotaurHorns>();
            OnHorns = Horns.OnHorns;
        }
    }

    public string GetEnemyName()
    {
        return EnemyName;
    }

    void Update()
    {
        if (Horns != null)
        {
            OnHorns = Horns.OnHorns;
            if (Horns != null && Input.GetKeyDown(KeyCode.Mouse0) && OnHorns)
            {
                Horns.TakeDamage(20f);
            }
            if (Horns != null && Horns.IsDead)
            {
                Horns.Die();
                NoHelmet = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.B) && playerinarea && attacking)
        {
            IsStun = true;
        }
        if (armorleft == 0) NoArmor = true;
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerinarea && healthBar != null)
        {
            if (!isType4 && !isMinotaur && IsStun)
            {
                healthBar.TakeDamage(20f);
            }
            else if (isType4 && NoArmor)
            {
                healthBar.TakeDamage(20f);
            }
            else if (isMinotaur && NoHelmet)
            {
                healthBar.TakeDamage(20f);
            }
        }
        if (healthBar.IsDead)
        {
            enigme3Waves.beaten = 1;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinarea = true;
        }
        if (other.CompareTag("Wall") && armorleft > 0 && isType4)
        {
            if (armorleft == 2) Destroy(Helmet);
            else Destroy(Armor);
            armorleft--;
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
