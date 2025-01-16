using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementIADeBase : MonoBehaviour
{
    public float vitesse = 2f;
    public float perimetre = 12f;
    public LayerMask solLayer;

    private Vector3 move;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        GenererNouvelleDestination();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, move, vitesse * Time.deltaTime);

        if (Vector3.Distance(transform.position, move) < 0.1f)
        {
            GenererNouvelleDestination();
        }

        Vector3 direction = move - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation *= Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, vitesse * 100 * Time.deltaTime);
        }
    }

    void GenererNouvelleDestination()
    {
        int maxTentatives = 10;
        for (int i = 0; i < maxTentatives; i++)
        {
            float NewX = Random.Range(-perimetre, perimetre);
            float NewZ = Random.Range(-perimetre, perimetre);

            Vector3 potentielMove = new Vector3(transform.position.x + NewX, transform.position.y + 5f, transform.position.z + NewZ);  // Ajuste le Raycast pour éviter le problème avec la hitbox

            if (Physics.Raycast(potentielMove, Vector3.down, out RaycastHit hit, Mathf.Infinity, solLayer))
            {
                float pente = Vector3.Angle(hit.normal, Vector3.up);
                if (pente <= 45f)
                {
                    float objectHeight = GetComponent<Collider>().bounds.extents.y;
                    move = new Vector3(hit.point.x, hit.point.y + objectHeight, hit.point.z);
                    return;
                }
            }
        }
        move = transform.position;
    }
}
