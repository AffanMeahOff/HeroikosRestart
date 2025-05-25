using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class Enigme3Manager : MonoBehaviour
{

    public GameObject interaction_Info_UI;


    public Camera Cam;

    private Enigme3Waves Waves;
    public bool hehasfinished = false;

    TMP_Text interaction_text;
    private bool sceneLoadingStarted = false;
    private bool finished;

    [SerializeField] private GameObject nextEnigme;
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();
        Waves = FindAnyObjectByType<Enigme3Waves>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            finished = true;
        }
        if (Waves != null) { finished = Waves.enigme3Finished; }
        if (finished)
        {
            Debug.Log("finished");
            hehasfinished = true;
            sceneLoadingStarted = true;
            NetworkManager.Singleton.SceneManager.OnLoadComplete += OnSceneLoaded;
            NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            Cursor.lockState = CursorLockMode.None;
            finished = false;
            nextEnigme.SetActive(true);

        }
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<Enigme3IO1>())
            {
                interaction_text.text = selectionTransform.GetComponent<Enigme3IO1>().GetEnemyName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                interaction_Info_UI.SetActive(false);
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
        nextEnigme.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
