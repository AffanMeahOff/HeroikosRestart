using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="New Item", menuName ="Item/Create")]

public class Item : MonoBehaviour
{
   public int id
   {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }
    public string ItemName
    {
        get
        {
            return ItemName;
        }
        set
        {
            ItemName = value;
        }
    }
    public int price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public Item(int ID, string name, int Price)
    {
        id = ID;
        ItemName = name;
        price = Price;
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}