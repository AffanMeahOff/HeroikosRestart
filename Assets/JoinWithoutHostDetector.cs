using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class JoinWithoutHostDetector : MonoBehaviour
{
    [SerializeField] private GameObject noHostWarningUI;
    [SerializeField] private Button joinButton;

    private void Start()
    {
        noHostWarningUI.SetActive(false);
        joinButton.onClick.AddListener(JoinGame);
    }

    private void JoinGame()
    {
        noHostWarningUI.SetActive(false);

        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

        bool success = NetworkManager.Singleton.StartClient();

        if (!success)
        {
                        ShowNoHostUI();
        }
    }

    private void OnClientDisconnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            ShowNoHostUI();
        }
    }

    private void ShowNoHostUI()
    {
        noHostWarningUI.SetActive(true);
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }
    public void closepan()
    {
        noHostWarningUI.SetActive(false);
    }

}



