using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public Transform player;
    public float attackRange = 12f;
    public float damage = 10f;
    public float attackCooldown = 1.5f;

    private NavMeshAgent agent;
    private float nextAttackTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerGO = GameObject.FindWithTag("Player");
        if (playerGO == null)
        {
            Debug.LogError("Aucun GameObject avec le tag 'Player' n'a été trouvé !");
            return;
        }

        player = playerGO.transform;

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent manquant sur le boss !");
        }
        if (player == null)
        {
            Debug.LogError("Le champ 'player' n'est pas assigné dans BossAI !");
        }
    }

    void Update()
    {
        if (player == null || agent == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        Debug.Log($"[BossAI] Distance au joueur: {distance}, attackRange: {attackRange}");

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Le boss n'est pas sur le NavMesh !");
            return;
        }

        if (agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            Debug.LogError("Le NavMeshAgent ne trouve pas de chemin valide vers le joueur !");
        }

        if (agent.isPathStale)
        {
            Debug.LogWarning("Le chemin du NavMeshAgent est obsolète !");
        }

        if (distance > attackRange)
        {
            Debug.Log($"[BossAI] Trop loin pour attaquer (distance: {distance} > attackRange: {attackRange})");
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            Debug.Log($"[BossAI] À portée d'attaque (distance: {distance} <= attackRange: {attackRange})");
            agent.isStopped = true;

            if (Time.time >= nextAttackTime)
            {
                Debug.Log("[BossAI] Cooldown terminé, attaque.");
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown;
            }
            else
            {
                Debug.Log($"[BossAI] Cooldown pas encore terminé. Time: {Time.time}, nextAttackTime: {nextAttackTime}");
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Tentative d'attaque du joueur");
        PlayerHealth ph = player.GetComponent<PlayerHealth>();
        if (ph != null)
        {
            float oldHealth = ph.health;
            ph.TakeDamage(damage);
            Debug.Log($"Le boss a frappé le joueur ! Santé avant: {oldHealth}, après: {ph.health}");
        }
        else
        {
            Debug.LogWarning("Aucun PlayerHealth trouvé sur l'objet joueur.");
        }
    }
}
