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

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")) // Assurez-vous que les objets ramassables ont le tag "Item"
        {
            Debug.Log($"🔹 Item détecté : {nearbyItemData.itemName}");
            ItemData item = other.GetComponent<ItemData>(); // Récupère l'ItemData
            if (item != null)
            {
                nearbyItemData = item;
                nearbyObject = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == nearbyObject)
        {
            nearbyItemData = null;
            nearbyObject = null;
            Debug.Log("🔹 Item hors de portée.");
        }
    }
    */

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







    /*
    if (Input.GetKeyDown(KeyCode.E))
    {
        CmdActivateObject();
    }

//A trigger volume in front of the player looks for objects with an 'interactable' tag, and when it finds them it will pass it into AssignInteractables!

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            AssignInteractables(other.gameObject);
            Debug.Log(other.gameObject.name);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AssignInteractables(null);
    }

//I use this to assign the object that will be interacted with

    public void AssignInteractables(GameObject interactable)
    {
        ObjectToAssign = interactable;
        if (ObjectToAssign != null) {
            Debug.Log(ObjectToAssign.name + " ready to assign!");
        }
    }


//This next part handles the interaction and the replication of the interaction on the server and across all other clients. It will reach into the interactable object and look for the Network Interaction script and then change its 'active' state.

[Command]
    void CmdActivateObject()
    {
        bool activStat = ObjectToAssign.GetComponent<NetworkInteraction>().PlayerActivated;
        activStat = !activStat;
        if(isServer)
        {
            RpcActivateObject(activStat);
        }
    }
    [ClientRpc]
    void RpcActivateObject(bool state)
    {
        ObjectToAssign.GetComponent<NetworkInteraction>().PlayerActivated = state;
    }

    public class NetworkInteraction : MonoBehaviour
    {
        [Header ("Activation State")]
        public bool PlayerActivated;
    }
    */

}
