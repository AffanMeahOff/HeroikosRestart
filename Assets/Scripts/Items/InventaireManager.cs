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
            if (invItem.item == item && invItem.quantity < item.maxStack)
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

    public void RemoveItem(ItemData item, int quantity)
    {
        InventaireItem invItem = items.Find(i => i.item == item);
        if (invItem != null)
        {
            invItem.quantity -= quantity;
            if (invItem.quantity <= 0)
                items.Remove(invItem);
        }
    }
}