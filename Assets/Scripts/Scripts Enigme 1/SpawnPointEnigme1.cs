using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class SpawnPointEnigme1 : NetworkBehaviour
{
    [SerializeField] private Transform player;

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
            Physics.SyncTransforms();
        }
    }
}
