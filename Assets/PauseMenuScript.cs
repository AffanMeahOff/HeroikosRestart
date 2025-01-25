using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void MultiplayerPannel() 
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void ReturnToGame() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadSceneAsync(1);
    }
}
