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
        if(other.CompareTag("TpEliott"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme2"); 
        }  
        if(other.CompareTag("TpThiago"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme3"); 
        }  
        if(other.CompareTag("TpAmine"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("Enigme4"); 
        }         
    }
}
