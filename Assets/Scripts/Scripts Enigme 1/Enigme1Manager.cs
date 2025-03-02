using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Enigme1Manager : MonoBehaviour
{
 
    public GameObject interaction_Info_UI;
    public Camera Cam;

    Text interaction_text;
 
    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }
 
    void Update()
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
