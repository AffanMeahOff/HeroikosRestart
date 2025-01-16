using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventaireManager : MonoBehaviour
{
    public static InventaireManager Instance;
    public List<GameObject> Items = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void Add(GameObject item)
    {
        Items.Add(item);
    }

    public void Remove(GameObject item)
    {
        Items.Remove(item);
    }
}