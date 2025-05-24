using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;

public class MainMenuScriptCam : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject optionsPannel;
    [SerializeField] private AudioSource audioSource;


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
    public void OpenPannel()
    {
        optionsPannel.SetActive(true);
    }
    public void ClosePannel()
    {
        optionsPannel.SetActive(false);
    }
    public void changesoundlevel()
    {
        audioSource.volume = slider.value;
    }
}
