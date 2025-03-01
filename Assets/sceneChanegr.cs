using UnityEngine;
using UnityEngine.SceneManagement;  


public class sceneChanegr : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Enigme1"); 
    }
}
