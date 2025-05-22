using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class NewPauseMenuScript : MonoBehaviour
{
    [SerializeField]private GameObject PauseMenu;
    
    public bool IsPause;
    void Start()
    {
        PauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(IsPause)
            {
                Cursor.lockState = CursorLockMode.Locked;
                ResumeGame();
            }
            else 
            {
                Cursor.lockState = CursorLockMode.None;
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        IsPause = true;
    }
    public void ExitGame()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void OpenMap()
    {

    }
    public void MultiplayerPannel()
    {

    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        IsPause = false;
    }
}
