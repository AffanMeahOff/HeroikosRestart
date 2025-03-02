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
        SceneManager.LoadSceneAsync(1);
    }
    public void Host()
    {
       SceneManager.LoadSceneAsync(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
