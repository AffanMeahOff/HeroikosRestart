using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NetworkManagerUI : MonoBehaviour 
{
    public void Serveur()
    {
        NetworkManager.Singleton.StartServer();
    }
    public void Client()
    {
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void Host()
    {
       NetworkManager.Singleton.StartHost();
       NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
