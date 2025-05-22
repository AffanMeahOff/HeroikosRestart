using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class MainMenuScriptCam : MonoBehaviour
{
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
                                                //SceneManager.LoadSceneAsync(1);
                                                //NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void MultiplayerPannel()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
