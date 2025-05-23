using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 20;
    public LayerMask attackLayer; // Définis une couche "Boss" dans l'inspecteur

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, attackLayer))
            {
                Debug.Log("Raycast a touché : " + hit.collider.name);

                BossController boss = hit.collider.GetComponent<BossController>();
                if (boss != null)
                {
                    boss.TakeDamage(damage);
                    Debug.Log("Dégâts infligés au boss !");
                }
                else
                {
                    Debug.LogWarning("L'objet touché n'est pas un boss.");
                }
            }
            else
            {
                Debug.Log("Raycast n’a rien touché.");
            }
        }
    }
}
