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
    [SerializeField]private Button ReturnButton;
    [SerializeField]private GameObject mainmenu;
    [SerializeField]private GameObject camera;
    [SerializeField]private GameObject camera2;
//    [SerializeField]private GameObject camera2;




    private void Awake() 
    {
        Server.onClick.AddListener (() => 
        {
            NetworkManager.Singleton.StartServer();
            gameObject.SetActive(false);
        });
        HostButton.onClick.AddListener(()=> 
        {
            NetworkManager.Singleton.StartHost();
            gameObject.SetActive(false);
        });
        ClientButton.onClick.AddListener(() => 
        {
            NetworkManager.Singleton.StartClient();
            gameObject.SetActive(false);
        });
        ReturnButton.onClick.AddListener(() =>
        {
            mainmenu.SetActive(true);
            camera.SetActive(false);
            camera2.SetActive(true);

            gameObject.SetActive(false); 
        });

    }
    

}
