using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    Text interaction_text;

    private InteractableObject currentInteractableObject;
    public Camera Camera;
    public GameObject NameObject;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<Text>();
    }   

    void Update()
{
    Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
        var selectionTransform = hit.transform;

        if (selectionTransform != null)
        {
            var interactableObject = selectionTransform.GetComponent<InteractableObject>();

            if (interactableObject != null)
            {
                interaction_Info_UI.SetActive(true);

                //interaction_text.text = interactableObject.GetItemName();
                currentInteractableObject = interactableObject;

                if (Input.GetKeyDown(KeyCode.P)) // Appuyez sur P pour ramasser
                {
                    PickUpObject(currentInteractableObject);
                }
            }
            else
            {
                interaction_Info_UI.SetActive(false);
                currentInteractableObject = null;
            }
        }
    }
    else
    {
        interaction_Info_UI.SetActive(false);
        currentInteractableObject = null;
    }

    if(Input.GetKeyUp(KeyCode.P))
    {
        NameObject.SetActive(true);
    }
}


    void PickUpObject(InteractableObject interactableObject)
    {
        if (interactableObject != null)
        {
            // Logique pour ramasser l'objet, par exemple l'ajouter à l'inventaire
            string name = interactableObject.GetItemName();
            Debug.Log("Picked Up : " + name);
            // Vous pouvez soit désactiver l'objet

            if (interactableObject.gameObject is GameObject item)
            {
                string nom = interactableObject.GetItemName();
                if(nom == "Jar") 
                {
                    InventaireManager.Instance.Add(item);
                
                }
                
            }


            interactableObject.gameObject.SetActive(false);
            // Ou le détruire
            // Destroy(interactableObject.gameObject);
        }
    }
} 