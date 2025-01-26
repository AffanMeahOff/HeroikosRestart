using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class MainMenuScriptCam : MonoBehaviour
{
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.None; //Pour eviter de sorir de l'ecran
        SceneManager.LoadSceneAsync(1);
    }
    public void MultiplayerPannel()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
