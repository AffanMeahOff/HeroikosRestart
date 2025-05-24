using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.Netcode;


public class playerProtectScript : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = respawnPosition;
    }
    public float secu = -20f;
    public Vector3 respawnPosition = new Vector3(217f, 50f, 190f);

    public GameObject endscreen;
    public Enigme1Manager enigme1Manager;


    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Enigme1" && transform.position.y < secu)
        {
            transform.position = new Vector3(679, 563, 308);
        }
        else if (sceneName == "Enigme2" && transform.position.y < secu)
        {
            transform.position = new Vector3(1100, 563, 84);
        }
        else if (sceneName == "Enigme3" && transform.position.y < secu || sceneName == "Enigme4" && transform.position.y < secu)
        {
            transform.position = new Vector3(679, 600, 308);
        }
        else if (transform.position.y < secu || enigme1Manager.hehasfinished)
        {
            Debug.Log("reset");
            enigme1Manager.hehasfinished = false;
            transform.position = respawnPosition;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndOfEnigme2"))
        {
            Cursor.lockState = CursorLockMode.None;
            endscreen.SetActive(true);
        }
        if (other.CompareTag("Death"))
        {
            transform.position = respawnPosition;
        }
        if (other.CompareTag("retp"))
        {
            Debug.Log("Dead");
            transform.position = new Vector3(1100, 563, 84);
        }
    }
    public void yes()
    {
        if (!IsOwner) return;
        endscreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
}
