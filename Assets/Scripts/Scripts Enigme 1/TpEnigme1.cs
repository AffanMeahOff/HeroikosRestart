using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class TpEnigme1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            gameObject.transform.position = new Vector3(679, 562, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme1", LoadSceneMode.Single);
        }
        if(other.CompareTag("TpEliott"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme2", LoadSceneMode.Single);
        }  
        if(other.CompareTag("TpThiago"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme3", LoadSceneMode.Single);
        }  
        if(other.CompareTag("TpAmine"))
        {
            gameObject.transform.position = new Vector3(600, 700, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme4", LoadSceneMode.Single);
        }         
    }
}
