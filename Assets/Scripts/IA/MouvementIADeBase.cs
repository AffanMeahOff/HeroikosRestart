using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MouvementIADeBase : MonoBehaviour
{
    public float vitesse = 0.2f;

    private Vector3 move; // Position cible
    private float timer = 0f;
    private float delai;
    private int idleormarche;

    void Start()
    {
        delai = Random.Range(1f, 4f);
        idleormarche = Random.Range(0, 2); 
        move = transform.position; 
    }

    void Update()
    {
        if (timer < delai)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            delai = Random.Range(1f, 4f);
            idleormarche = Random.Range(0, 2);

            if (idleormarche == 0) 
            {
                Debug.Log("Mode Idle...");
            }
            else 
            {
                float NewX = Random.Range(-4f, 4f);
                float NewZ = Random.Range(-4f, 4f);

                move = new Vector3(transform.position.x + NewX, transform.position.y, transform.position.z + NewZ);
            }
        }

        if (idleormarche == 1)
        {
            //transform.position = Vector3.MoveTowards(transform.position, move, vitesse * Time.deltaTime);
            transform.position = move;

            if (Vector3.Distance(transform.position, move) < 0.1f)
            {
                idleormarche = 0; 
            }
        }
    }
}

