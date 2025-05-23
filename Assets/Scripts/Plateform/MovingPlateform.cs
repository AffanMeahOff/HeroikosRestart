using UnityEngine;

public class SimpleMovingPlatform : MonoBehaviour
{
    private Transform playerOnPlatform = null;
    private float toupdate;

    void Start()
    {
        toupdate = transform.position.x;
    }

    void Update()
    {
        toupdate = transform.position.x;

        if (playerOnPlatform != null)
        {
            playerOnPlatform.position = new Vector3(toupdate ,playerOnPlatform.position.y, playerOnPlatform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colision");
            playerOnPlatform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerOnPlatform == other.transform)
                playerOnPlatform = null;
            Debug.Log("Tombe");

        }
    }
}

