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
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
    public void ReturnToGame() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
    }

}
