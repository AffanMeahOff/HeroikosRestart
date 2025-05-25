using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;

public class NewPauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject map;

    [SerializeField] private GameObject Settings;


    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioSource bossMusic;
    //[SerializeField] private AudioSource krustals;
    //[SerializeField] private AudioSource jump;
    //[SerializeField] private AudioSource combat;
    [SerializeField] private Slider slider;


    public bool IsPause;
    void Start()
    {
        PauseMenu.SetActive(false);
        map.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (IsPause)
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
        NetworkManager.Singleton.Shutdown();
        SceneManager.LoadSceneAsync(1);
    }
    public void OpenMap()
    {
        map.SetActive(true);
    }
    public void closeMap()
    {
        map.SetActive(false);
    }
    public void oset()
    {
        Settings.SetActive(true);
    }
    public void cset()
    {
        Settings.SetActive(false);
    }

    public void Enigme1()
    {
        player.transform.position = new Vector3(-653, 0, 89);
        PauseMenu.SetActive(false);
        map.SetActive(false);
        IsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Enigme2()
    {
        player.transform.position = new Vector3(-733, 0, 743);
        PauseMenu.SetActive(false);
        map.SetActive(false);
        IsPause = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Enigme3()
    {
        player.transform.position = new Vector3(352, 0, 599);
        PauseMenu.SetActive(false);
        map.SetActive(false);
        IsPause = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void Enigme4()
    {
        player.transform.position = new Vector3(76, 0, 223);
        PauseMenu.SetActive(false);
        map.SetActive(false);
        IsPause = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void MultiplayerPannel()
    {
        NetworkManager.Singleton.Shutdown();
        SceneManager.LoadSceneAsync(3);
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        map.SetActive(false);
        IsPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void changesoundlevel()
    {
        audioSource.volume = slider.value;
    }
}
