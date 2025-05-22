using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class Enigme3Manager : MonoBehaviour
{
 
    public GameObject interaction_Info_UI;
    public Camera Cam;

    public Enigme3Waves Waves;

    TMP_Text interaction_text;
 
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();
    }
 
    void Update()
    {
        bool finished = Waves.enigme3Finished;
        if(finished)
        {
            return;
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
}
