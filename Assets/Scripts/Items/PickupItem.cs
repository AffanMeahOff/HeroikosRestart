using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public InventaireManager inventory;  // Référence à l'inventaire
    public InventaireUI UI;              // Référence à l'UI

    private ItemData nearbyItemData;     // Stocke l'ItemData de l'objet proche
    private GameObject nearbyObject;     // Stocke le GameObject de l'objet proche
  
    public Camera Cam;

    

    private void Update()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                
                if (Input.GetKeyDown(KeyCode.P))
                {
                    ItemData item = selectionTransform.GetComponent<ItemData>(); // Récupère l'ItemData
                    GameObject obj = selectionTransform.gameObject;
                    Debug.Log($"🛠 Tentative de ramassage : {item.itemName}");

                    if (inventory.AddItem(item, 1)) // Ajoute l'item à l'inventaire
                    {
                        Debug.Log($"✅ {item.itemName} ramassé !");
                        UI.UpdateUI();
                        Destroy(obj);
                        item = null;
                        obj = null;
                    }
                    
                }
            }
 
        }
        
    }

}
