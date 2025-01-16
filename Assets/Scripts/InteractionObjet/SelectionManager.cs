using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    public Text interaction_text;
    private InteractableObject currentInteractableObject;
    Ray ray;
    RaycastHit hit;

    public Camera Camera;

    private void Start()
    {
        ray = new Ray();
        hit = new RaycastHit();
    }

    void Update()
    {
        ray = Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            var interactableObject = selectionTransform.GetComponent<InteractableObject>();

            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interaction_Info_UI.SetActive(true);
                
                currentInteractableObject = interactableObject;

                if (Input.GetKeyDown(KeyCode.P)) // Appuyez sur E pour ramasser
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
        else
        {
            interaction_Info_UI.SetActive(false);
            currentInteractableObject = null;
        }
    }

    void PickUpObject(InteractableObject interactableObject)
    {
        if (interactableObject != null)
        {
            // Logique pour ramasser l'objet, par exemple l'ajouter à l'inventaire
            Debug.Log("Ramassé : " + interactableObject.GetItemName());
            // Vous pouvez soit désactiver l'objet
            interactableObject.gameObject.SetActive(false);
            // Ou le détruire
            // Destroy(interactableObject.gameObject);
        }
    }
} 