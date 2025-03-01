using UnityEngine;
using UnityEngine.SceneManagement;


public class SpawnPointEnigme1 : MonoBehaviour
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
            spawnPoint = GameObject.Find("Spawn");
            player.SetPositionAndRotation(spawnPoint.transform.position, player.transform.rotation);
            Physics.SyncTransforms();
        }
    }
}
