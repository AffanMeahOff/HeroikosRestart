using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireManager : MonoBehaviour
{
    public static InventaireManager Instance;
    //public GameObject InventoryItem;
    public GameObject itembutton;
    //public Transform ItemContent;
    public List<GameObject> Items = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }



    public void Add(GameObject item)
    {
        
        Items.Add(item);
        Debug.Log("Added to list");
        GameObject ItemButton = Instantiate(itembutton);
    }

    public void Remove(GameObject item)
    {
        Items.Remove(item);
    }

    /*public void ListItems()
    {
        //Pour éviter que les items ne se multiplient à chaque ouverture de l'inventaire
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            itemName.text = "filler name";

        }
    }
    */
}