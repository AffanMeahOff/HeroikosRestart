using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalScript : MonoBehaviour
{
    [SerializeField] Button StartNewGame;
    [SerializeField] Button JoinGame;

    [SerializeField] Button LoadGame;
    [SerializeField] GameObject MultiplayerPannel;
    [SerializeField] GameObject Camera;


    void Awake()
    {
        StartNewGame.onClick.AddListener(StartGame);
        JoinGame.onClick.AddListener(MultiplayerPannelActivator);
    }

    void StartGame()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
    void MultiplayerPannelActivator()
    {
        MultiplayerPannel.SetActive(true);
        Camera.SetActive(false);
        gameObject.SetActive(false);
    }
}