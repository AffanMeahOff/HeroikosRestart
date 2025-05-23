using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkTp : NetworkBehaviour
{
    [SerializeField] private TpEnigme1 tp;

    public void Update()
    {
        // if (tp.e1)
        // {
        //     gameObject.transform.position = new Vector3(679, 563, 308);
        //     tp.e1 = false;  
        // }
    }



    private void Start()
    {
        if (IsOwner)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //if (!IsOwner) return;
        Debug.Log("scene loaded");

        string sceneName = scene.name;

        if (sceneName == "Enigme1")
        {
            transform.position = new Vector3(110, 50, 330);
        }
        else if (sceneName == "Enigme2")
        {
            transform.position = new Vector3(1084, 563, 84);
        }
        else if (sceneName == "Enigme3" || sceneName == "Enigme4")
        {
            transform.position = new Vector3(679, 560, 308);
        }

        Debug.Log($"Teleported to {transform.position} in scene {sceneName}");

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
