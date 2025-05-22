using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class TpEnigme1 : MonoBehaviour
{
    [SerializeField] private PlayerMovement jumpscript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            gameObject.transform.position = new Vector3(679, 563, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme1", LoadSceneMode.Single);
        }
        if (other.CompareTag("TpEliott"))
        {
            gameObject.transform.position = new Vector3(1084, 563, 84);
            Physics.SyncTransforms();
            jumpscript.jumpHeight = 4;
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme2", LoadSceneMode.Single);
        }
        if (other.CompareTag("TpThiago"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme3", LoadSceneMode.Single);
        }
        if (other.CompareTag("TpAmine"))
        {
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme4", LoadSceneMode.Single);
        }
    }
}
