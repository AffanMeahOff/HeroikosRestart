using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class sceneChanegr : MonoBehaviour
{
    //[SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("contact");
            }
    }
}
