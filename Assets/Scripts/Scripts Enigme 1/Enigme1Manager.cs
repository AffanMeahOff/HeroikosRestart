using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class Enigme1Manager : MonoBehaviour
{
 
    public GameObject interaction_Info_UI;
    public Camera Cam;

    private Enigme1Counter Counter;
    TMP_Text interaction_text;

    private void Start()
    {
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
            gameObject.transform.position = new Vector3(679, 560, 308);
            Physics.SyncTransforms();
            //gameObject.transform.SetPositionAndRotation(new Vector3(679, 560, 308), gameObject.transform.rotation);
            SceneManager.LoadScene("SampleScene");
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
}
