using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class playerProtectScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = respawnPosition;
    }
    public float secu = -20f;
    public Vector3 respawnPosition = new Vector3(217f, 50f, 190f);
    // Update is called once per frame
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Enigme1" && transform.position.y < secu)
        {
            transform.position = new Vector3(679, 563, 308);
        }
        else if (sceneName == "Enigme2" && transform.position.y < secu)
        {
            transform.position = new Vector3(1084, 563, 84);
        }
        else if (sceneName == "Enigme3" && transform.position.y < secu || sceneName == "Enigme4" && transform.position.y < secu)
        {
            transform.position = new Vector3(679, 560, 308);
        }
        else if (transform.position.y < secu)
        {
            transform.position = respawnPosition;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
}
