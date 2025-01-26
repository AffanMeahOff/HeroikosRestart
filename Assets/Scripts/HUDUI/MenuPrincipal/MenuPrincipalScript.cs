using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalScript : MonoBehaviour
{
    [SerializeField] Button StartNewGame;
    [SerializeField] GameObject Camera;


    void Awake()
    {
        StartNewGame.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
}