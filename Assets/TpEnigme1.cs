using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpEnigme1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Teleporter"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme1"); 
        }
        if(other.CompareTag("Teleporter2"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme2"); 
        }  
        if(other.CompareTag("Teleporter3"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme3"); 
        }       
    }
}
