using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class Enigme1Manager : NetworkBehaviour
{
    public GameObject interaction_Info_UI;
    public GameObject Thisplayer;
    public Camera Cam;

    private Enigme1Counter Counter;
    TMP_Text interaction_text;

    public bool hehasfinished = false;
    private bool sceneLoadingStarted = false;

    [SerializeField] private GameObject EndEnigme;
    [SerializeField] private GameObject nextEnigme;

    private void Start()
    {
        hehasfinished = false;
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();
        Counter = FindAnyObjectByType<Enigme1Counter>();
    }

    public bool CanEnableSword()
    {
        return Counter != null && Counter.enigme1Finished;
    }

    void Update()
    {
        if (!IsServer) return; 

        if (sceneLoadingStarted) return;

        Counter = FindAnyObjectByType(typeof(Enigme1Counter)) as Enigme1Counter;
        if (Input.GetKeyDown(KeyCode.L)) Counter.collected = 10;
        if (Counter != null && Counter.enigme1Finished)
        {
            hehasfinished = true;
            sceneLoadingStarted = true;

            NetworkManager.Singleton.SceneManager.OnLoadComplete += OnSceneLoaded;
            NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            Cursor.lockState = CursorLockMode.None;
            EndEnigme.SetActive(true);
        }

        if (IsClient)
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selectionTransform = hit.transform;
                if (selectionTransform.GetComponent<Enigme1IO1>())
                {
                    interaction_text.text = selectionTransform.GetComponent<Enigme1IO1>().GetItemName();
                    interaction_Info_UI.SetActive(true);
                }
                else
                {
                    interaction_Info_UI.SetActive(false);
                }
            }
        }
    }

    private void OnSceneLoaded(ulong clientId, string sceneName, LoadSceneMode mode)
    {
        if (sceneName != "SampleScene") return;

        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            var player = client.PlayerObject;
            if (player != null)
            {
                Debug.Log("tped");
                player.transform.position = new Vector3(194, 5, 203);
            }
        }

        Physics.SyncTransforms();
        NetworkManager.Singleton.SceneManager.OnLoadComplete -= OnSceneLoaded;
    }

    public void ok()
    {
        EndEnigme.SetActive(false);
        nextEnigme.SetActive(true);
    }

    public void wecango()
    {
        nextEnigme.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
