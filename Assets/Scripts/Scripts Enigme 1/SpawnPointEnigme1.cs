using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Unity.Netcode.Components;


public class SpawnPointEnigme1 : NetworkBehaviour
{
    [SerializeField] private Transform player;
    private GameObject spawnPoint;

    private void Onable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }
    private void ODisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }
    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Enigme1")
        {
            //spawnPoint = GameObject.Find("Spawn");
            //player.GetComponent<CharacterController>().enabled = false;
            //player.transform.position = new Vector3(679,560,308);
            //player.GetComponent<CharacterController>().enabled = true;
            //player.SetPositionAndRotation(new Vector3(679,560,308), player.transform.rotation);
            Physics.SyncTransforms();
        }
    }
}
