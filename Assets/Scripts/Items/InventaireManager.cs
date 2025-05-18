using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventaireManager : MonoBehaviour
{
    public List<InventaireItem> items = new List<InventaireItem>();
    public int maxSlots = 27;

    public bool AddItem(ItemData item, int quantity)
    {

        foreach (InventaireItem invItem in items)
        {
            Debug.Log($"Nouveau: {item.itemName} ajouté au stack.");
            if (invItem.item.ID == item.ID && invItem.quantity < item.maxStack)
            {
                invItem.quantity += quantity;
                Debug.Log($"Ajouté: {item.itemName} (Quantité: {invItem.quantity})");
                return true;
            }
        }

        if (items.Count < maxSlots)
        {
            items.Add(new InventaireItem(item, quantity));
            Debug.Log($"Nouveau: {item.itemName} ajouté à l'inventaire.");
            return true;
        }

        return false;
    }

    public void RemoveItem(ItemData item, int quantity=1)
    {
        InventaireItem invItem = items.Find(i => i.item.ID == item.ID);
        if (invItem != null)
        {
            invItem.quantity -= quantity;
            if (invItem.quantity <= 0)
                items.Remove(invItem);
        }
    }
}