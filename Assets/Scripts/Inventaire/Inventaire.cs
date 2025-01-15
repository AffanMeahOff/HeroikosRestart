using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class Inventaire
{
    public Item[][] inventaire;

    private void Awake()
    {
        inventaire = new Item[9][];
        int i = 0;
        while(i < 9)
        {
            inventaire[i] = new Item[3];
            i++;
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
}