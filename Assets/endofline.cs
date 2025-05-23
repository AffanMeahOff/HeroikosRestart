using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class endofline : MonoBehaviour
{
    private Transform player = null;
    void Update()
    {
        if (player != null)
        {
            Debug.Log("End");
            NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            player.transform.position = new Vector3(194, 5, 203);
            Physics.SyncTransforms();
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
