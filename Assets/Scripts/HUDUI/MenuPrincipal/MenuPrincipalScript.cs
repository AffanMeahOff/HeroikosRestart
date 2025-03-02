using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalScript : MonoBehaviour
{
    [SerializeField] Button StartNewGame;
    [SerializeField] Button Join;

    [SerializeField] GameObject Camera;


    void Awake()
    {
        StartNewGame.onClick.AddListener(StartGame);
        Join.onClick.AddListener(Joingame);

    }

    void StartGame()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
    void Joingame()
    {
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }
}