using UnityEngine;

public class deathzone : MonoBehaviour
{
    private Transform player = null;

    void Update()
    {
        if (player != null)
        {
            player.transform.position = new Vector3(1100, 563, 84);
            player = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }
}
