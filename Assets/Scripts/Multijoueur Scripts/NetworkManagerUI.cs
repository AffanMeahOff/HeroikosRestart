using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NetworkManagerUI : MonoBehaviour 
{
    [SerializeField]private GameObject serveurset;
    [SerializeField] private TMP_InputField ipInput;
    [SerializeField] private TMP_InputField portInput;

    public void Serveur()
    {
        serveurset.SetActive(true);
    }
    public void setip()
    {
        var networkManager = FindAnyObjectByType<NetworkManager>();
        if (networkManager == null)
        {
            return;
        }

        var transport = networkManager.GetComponent<UnityTransport>();
        if (transport == null)
        {
            return;
        }

        string ip = ipInput.text;
        if (!ushort.TryParse(portInput.text, out ushort port))
        {
            return;
        }

        transport.ConnectionData.Address = ip;
        transport.ConnectionData.Port = port;
    }

    public void exitServSet()
    {
        serveurset.SetActive(false);
    }
    public void Client()
    {
        //NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        SceneManager.LoadScene("SampleScene");
        NetworkManager.Singleton.StartClient();
    }
    public void Host()
    {
       NetworkManager.Singleton.StartHost();
       NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
