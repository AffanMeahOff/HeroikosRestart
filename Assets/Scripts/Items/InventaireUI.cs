using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

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
        foreach (Transform child in inventoryPanel)
        {
            if (child.gameObject != inventorySlotPrefab) // Ne pas détruire l'original
            {
                Destroy(child.gameObject);
            }
        }
        foreach (InventaireItem item in inventory.items)
        {
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            slot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.item.itemName;
        }
    }
}
