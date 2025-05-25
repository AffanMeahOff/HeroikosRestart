using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinWithoutHostDetector : MonoBehaviour
{
    [SerializeField] private GameObject noHostWarningUI;
    [SerializeField] private Button joinButton;

    private bool triedToConnect = false;

    private void Start()
    {
        noHostWarningUI.SetActive(false);
        joinButton.onClick.AddListener(JoinGame);
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;
    }

    private void JoinGame()
    {
        noHostWarningUI.SetActive(false);
        triedToConnect = true;
        Debug.Log("clicked");

        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

        NetworkManager.Singleton.StartClient();
    }

    private void OnClientConnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Connected to host.");
            triedToConnect = false;
            SceneManager.LoadScene("SampleScene");

            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
        }
    }


    private void OnClientDisconnected(ulong clientId)
    {
        if (clientId == NetworkManager.Singleton.LocalClientId && triedToConnect)
        {
            Debug.Log("tried");
            noHostWarningUI.SetActive(true);
            triedToConnect = false;
        }
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
