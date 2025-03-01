using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
public class InventaireManager : MonoBehaviour
{
    
    public static InventaireManager Instance;

    public GameObject itembutton; // Bouton représentant l'item dans l'UI
    public Transform ItemContent; // Conteneur des items dans l'inventaire UI
    public GameObject InventoryItem; // Préfab d'un item affiché dans l'inventaire
    public List<GameObject> Items = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Add(GameObject item)
    {
        if (item == null) return;

        Items.Add(item);
        Debug.Log("Added to list: " + item.name);

        // Ajoute un bouton d'item dans l'inventaire UI
        GameObject ItemButton = Instantiate(itembutton, ItemContent);
    }

    public void Remove(GameObject item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
        }
    }

    public void ListItems()
    {
        if (ItemContent == null) return;

        // Nettoyer les items existants pour éviter la duplication
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        // Ajouter chaque item de la liste dans l'inventaire UI
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName")?.GetComponent<Text>();

            if (itemName != null)
            {
                itemName.text = item.name; // Mettre le vrai nom de l'item
            }
        }
    }
    

}
*/

public class InventaireManager : MonoBehaviour
{
    public List<InventaireItem> items = new List<InventaireItem>();
    public int maxSlots = 27;

    /*
    void Awake()
    {
        Debug.Log($"📦 Inventory trouvé sur {gameObject.name}, actif : {gameObject.activeInHierarchy}");
        Debug.Log($"📦 UI trouvé sur {gameObject.name}, actif : {gameObject.activeInHierarchy}");
    }
    */

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