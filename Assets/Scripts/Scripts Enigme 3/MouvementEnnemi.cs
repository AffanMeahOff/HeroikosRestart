using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemi : MonoBehaviour
{
    public float vitesse = 2f;
    public float distanceSeuil = 3f; // Stop this close to attack
    public LayerMask solLayer;

    private Vector3 move;
    private Transform player;
    public Transform forwardPoint;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("No GameObject with tag 'Player' found.");
        }

        // Fallback: use transform as forwardPoint if not set
        if (forwardPoint == null)
        {
            forwardPoint = this.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Rotate toward the player at all times
        Vector3 direction = (player.position - forwardPoint.position).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, vitesse * 100 * Time.deltaTime);
        }

        // Only move if outside attack range
        if (distanceToPlayer > distanceSeuil)
        {
            move = player.position;
            transform.position = Vector3.MoveTowards(transform.position, move, vitesse * Time.deltaTime);
        }
        else
        {
            // Optional: Trigger attack animation here
            move = Vector3.zero;
            Debug.Log("Enemy is close enough to attack!");
            // GetComponent<Animator>().SetTrigger("Attack");
        }
    }
}
