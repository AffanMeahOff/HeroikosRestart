using UnityEngine;

public class MouvementEnnemi : MonoBehaviour
{
    public float vitesse = 2f;
    public float distanceSeuil = 5f;
    public float rotationSpeed = 360f;
    public bool ischarger;
    public float damage;
    public float chargedamage;
    public float chargeForce = 500f;
    public float chargeDistanceThreshold = 5f;
    public float chargeCooldown = 5f;
    public float chargeDuration = 1f;
    private bool isStunned = false;
    private float stunTimer = 0f;
    private PlayerHealth healthplayer;
    private float chargeCooldownTimer = 0f;
    private float chargeTimer = 0f;
    private bool isCharging = false;
    private Vector3 chargeDirection;
    private Transform player;
    public Transform forwardPoint;
    private Animator animator;
    private Rigidbody rb;

    private bool attacking;

    void Start()
    {
        healthplayer = player.GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        animator = GetComponent<Animator>();
        if (animator == null) Debug.LogWarning("Animator component missing.");

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        else Debug.LogWarning("No GameObject with tag 'Player' found.");

        if (forwardPoint == null)
        {
            Debug.LogWarning("forwardPoint not set. Defaulting to self.");
            forwardPoint = transform;
        }
    }

    void Update()
    {
        if (player == null || animator == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if (stunTimer <= 0f)
            {
                isStunned = false;
            }
            return; // Skip all other behavior
        }
        if (ischarger)
        {
            if (chargeCooldownTimer > 0f)
                chargeCooldownTimer -= Time.deltaTime;
            if (isCharging)
            {
                chargeTimer -= Time.deltaTime;
                if (chargeTimer <= 0f)
                {
                    StopCharge();
                }
                return; // Skip other logic while charging
            }
        }

        // Rotate toward the player
        Vector3 direction = (player.position - forwardPoint.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        attacking = currentState.IsName("Attack") || currentState.IsName("Charge"); ;

        if (!attacking)
        {
            if (ischarger && distanceToPlayer <= chargeDistanceThreshold && chargeCooldownTimer <= 0f)
            {
                PerformChargeAttack(direction);
            }
            else if (distanceToPlayer > distanceSeuil)
            {
                Debug.Log("Walking");
                transform.position = Vector3.MoveTowards(transform.position, player.position, vitesse * Time.deltaTime);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                Debug.Log("Attacking");
                animator.SetBool("IsWalking", false);
                if (!currentState.IsName("Attack"))
                {
                    animator.SetTrigger("Attack");
                }
                if (distanceToPlayer > distanceSeuil) healthplayer.TakeDamage(damage);
            }
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    private void PerformChargeAttack(Vector3 direction)
    {
        Debug.Log("Charging with force!");

        animator.SetTrigger("Charge");

        chargeDirection = direction;
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(chargeDirection * chargeForce, ForceMode.Impulse);

        isCharging = true;
        chargeTimer = chargeDuration;
        chargeCooldownTimer = chargeCooldown;
    }
    private void StopCharge()
    {
        isCharging = false;
        rb.linearVelocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isCharging)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player during charge!");
                healthplayer.TakeDamage(chargedamage);
            }
            else if (collision.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Hit wall during charge!");
                Stun(10f);
            }

            StopCharge(); // Stop immediately after any collision
        }
    }
    public void Stun(float duration)
    {
        Debug.Log("Enemy is stunned!");

        isStunned = true;
        stunTimer = duration;
        rb.linearVelocity = Vector3.zero;
        isCharging = false;

        animator.SetBool("IsWalking", false);
    }
}
