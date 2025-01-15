using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalScript : MonoBehaviour
{
    [SerializeField] Button StartNewGame;
    [SerializeField] Button Multiplayer;

    [SerializeField] Button LoadGame;
    [SerializeField] GameObject MultiplayerPannel;

    void Awake()
    {
        StartNewGame.onClick.AddListener(StartGame);
        Multiplayer.onClick.AddListener(MultiplayerPannelActivator);
    }

    void StartGame()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
    void MultiplayerPannelActivator()
    {
        MultiplayerPannel.SetActive(true);
        gameObject.SetActive(false);
    }
}
