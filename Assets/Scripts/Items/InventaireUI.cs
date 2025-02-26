using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventaireUI : MonoBehaviour
{
    public InventaireManager inventory;
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel;

    public void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("Mise à jour de l'inventaire UI...");
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (InventaireItem item in inventory.items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = item.item.icon;
            slot.transform.GetChild(1).GetComponent<Text>().text = item.quantity.ToString();
        }
    }
}
