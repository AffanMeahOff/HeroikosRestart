using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class TpEnigme1 : NetworkBehaviour
{
    [SerializeField] private PlayerMovement jumpscript;
    public bool e1 = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!NetworkManager.Singleton.IsServer) return; //Host Is King !

        if (other.CompareTag("Teleporter"))
        {
            //gameObject.transform.position = new Vector3(679, 564, 308);
            //Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme1", LoadSceneMode.Single);
            e1 = true;
        }
        if (other.CompareTag("TpEliott"))
        {
            //gameObject.transform.position = new Vector3(1084, 563, 84);
            //Physics.SyncTransforms();
            jumpscript.jumpHeight = 4;
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme2", LoadSceneMode.Single);
        }
        if (other.CompareTag("TpThiago"))
        {
            //gameObject.transform.position = new Vector3(679, 560, 308);
            //Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme3", LoadSceneMode.Single);
        }
        if (other.CompareTag("TpAmine"))
        {
            //gameObject.transform.position = new Vector3(679, 560, 308);
            //xPhysics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            NetworkManager.Singleton.SceneManager.LoadScene("Enigme4", LoadSceneMode.Single);
        }
    }
}
