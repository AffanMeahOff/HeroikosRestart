using UnityEngine;
using System;


public class MouvementEnnemi : MonoBehaviour
{
    public float vitesse = 2f;
    public float distanceSeuil = 5f;
    public float rotationSpeed = 360f;
    public bool ischarger;
    public float damage;
    public float chargedamage;
    public float chargeForce = 5f;
    public float chargeDistanceThreshold = 5f;
    public float chargeCooldown = 5f;
    public float chargeDuration = 4f;
    public bool isStunned = false;
    public float attackCooldown = 3f;           // Cooldown duration in seconds
    private float attackCooldownTimer = 0f;     // Tracks cooldown state

    private float stunTimer = 0f;
    private float chargeCooldownTimer = 0f;
    private float chargeTimer = 0f;
    private bool isCharging = false;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 chargeDirection = Vector3.zero;

    private PlayerHealth healthplayer;
    private Transform player;
    public Transform forwardPoint;
    private Animator animator;
    private Rigidbody rb;

    public bool attacking;

    void Start()
    {
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

        healthplayer = player.GetComponent<PlayerHealth>();

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
                isStunned = false;
            return;
        }
        // Reduce attack cooldown timer
        if (attackCooldownTimer > 0f)
            attackCooldownTimer -= Time.deltaTime;

        
        if (ischarger)
        {
            if (chargeCooldownTimer > 0f)
                chargeCooldownTimer -= Time.deltaTime;

            if (isCharging)
            {
                chargeTimer -= Time.deltaTime;
                if (chargeTimer <= 0f)
                    StopCharge();
                return;
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
        attacking = currentState.IsName("Attack") || currentState.IsName("Charge");

        if (!attacking)
        {
            if (ischarger && distanceToPlayer <= chargeDistanceThreshold && chargeCooldownTimer <= 0f)
            {
                PerformChargeAttack(direction);
                return;
            }
            
            if (distanceToPlayer > distanceSeuil)
            {
                moveDirection = (player.position - transform.position).normalized;
                moveDirection.y = 0f;
                animator.SetBool("IsWalking", true);
            }
            else
            {
                moveDirection = Vector3.zero;
                animator.SetBool("IsWalking", false);
                if (attackCooldownTimer <= 0f && !currentState.IsName("Attack"))
                {
                    animator.SetTrigger("Attack");
                    attackCooldownTimer = attackCooldown; // Reset cooldown
                    if (distanceToPlayer <= distanceSeuil)
                        healthplayer.TakeDamage(damage);
                }
            }
        }
        else
        {
            moveDirection = Vector3.zero;
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
       

        if (isStunned) return;

        if (isCharging)
        {
            Vector3 movement = chargeDirection * chargeForce * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
        else if (moveDirection != Vector3.zero)
        {
            Vector3 movement = moveDirection * vitesse * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            
        }
    }

    private void PerformChargeAttack(Vector3 direction)
    {
        Debug.Log("Charging with force!");

        animator.SetTrigger("Charge");

        chargeDirection = direction;
        chargeDirection.y = 0f;
        chargeDirection = chargeDirection.normalized;

        isCharging = true;
        chargeTimer = chargeDuration;
        chargeCooldownTimer = chargeCooldown;
    }

    private void StopCharge()
    {
        Debug.Log("Stopped Charging");
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

            StopCharge();
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
