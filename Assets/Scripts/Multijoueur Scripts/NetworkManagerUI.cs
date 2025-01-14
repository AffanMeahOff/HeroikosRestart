using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
public class NetworkManagerUI : MonoBehaviour 
{
    [SerializeField]private Button Server;
    [SerializeField]private Button HostButton; 
    [SerializeField]private Button ClientButton;

    private void Awake() 
    {
        Server.onClick.AddListener (() => 
        {
            NetworkManager.Singleton.StartServer();
        });
        HostButton.onClick.AddListener(()=> 
        {
            NetworkManager.Singleton.StartHost();
        });
        ClientButton.onClick.AddListener(() => 
        {
            NetworkManager.Singleton.StartClient();
        });

    }
    

}
