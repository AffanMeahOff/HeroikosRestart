using UnityEngine;
using UnityEngine.UI;
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
            slot.transform.GetComponentInChildren<Image>().sprite = item.item.icon;
            if(item.quantity > 1) slot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " (" + item.quantity
            + ")";
        }
    }
}
