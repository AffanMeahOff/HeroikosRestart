using UnityEngine;

public class SimpleMovingPlatform : MonoBehaviour
{
    private Transform player = null;
    private float toupdate;

    void Start()
    {
        toupdate = transform.position.x;
    }

    void Update()
    {
        toupdate = transform.position.x;

        if (player != null)
        {
            player.position = new Vector3(toupdate ,player.position.y, player.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colision");
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player == other.transform)
            { 
            player = null;
            }
            Debug.Log("Tombe");

        }
    }
}

