using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemi : MonoBehaviour
{
    public float vitesse = 2f;
    public float distanceSeuil = 3f;

    private Vector3 move;
    private Transform player;
    public Transform forwardPoint;

    public bool attacking;

    private Animator animator;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        animator = GetComponent<Animator>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'Player' found.");
        }

        if (forwardPoint == null)
        {
            forwardPoint = this.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Always face the player
        Vector3 direction = (player.position - forwardPoint.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, vitesse * 100 * Time.deltaTime);
        }

        // Update attack state from Animator
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0); // Base Layer
        attacking = currentState.IsName("Attack");

        // If not attacking, handle movement and attack triggering
        if (!attacking)
        {
            if (distanceToPlayer > distanceSeuil)
            {
                // Move toward the player
                move = player.position;
                transform.position = Vector3.MoveTowards(transform.position, move, vitesse * Time.deltaTime);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                // In range to attack, stop movement and trigger attack
                animator.SetBool("IsWalking", false);

                // Prevent spamming the trigger
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                {
                    animator.SetTrigger("Attack");
                }
            }
        }
        else
        {
            // If attacking, make sure the enemy is not walking or moving
            animator.SetBool("IsWalking", false);
        }
        if(distanceToPlayer > distanceSeuil) animator.SetBool("IsWalking", true);

    }
}

