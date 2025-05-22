using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class CameraScript : NetworkBehaviour
{
    public GameObject cameraHolder;
    void Start()
    {
        if (IsLocalPlayer)
        {
            cameraHolder.SetActive(true);
        }
    }
}
