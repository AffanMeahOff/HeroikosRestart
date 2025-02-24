using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventaireUI : MonoBehaviour
{
    public Inventaire inventory;
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
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
