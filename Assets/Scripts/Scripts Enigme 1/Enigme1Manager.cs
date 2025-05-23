using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Enigme1Manager : MonoBehaviour
{

    public GameObject interaction_Info_UI;
    public GameObject Thisplayer;

    public Camera Cam;

    private Enigme1Counter Counter;
    TMP_Text interaction_text;

    public bool hehasfinished = false;

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
        Counter = FindAnyObjectByType(typeof(Enigme1Counter)) as Enigme1Counter;
        bool finished = false;
        if (Counter is not null)
        {
            finished = Counter.enigme1Finished;
        }
        if (Counter is not null && finished)
        {
            hehasfinished = true;
            NetworkManager.Singleton.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            Thisplayer.transform.position = new Vector3(194, 5, 203);
            Physics.SyncTransforms();
            Cursor.lockState = CursorLockMode.None;
            EndEnigme.SetActive(true);
        }
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
    public void ok()
    {
        EndEnigme.SetActive(false);
        nextEnigme.SetActive(true);
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void wecango()
    {
        nextEnigme.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
