using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Epee : Item
{
    
    public GameObject Longsword;
    public int Dégâts;
    public int Durabilité;
    public Epee (int id, string name, int price, int maxStack) : base (id, name, price, maxStack)
    {

    }
    private void Awake()
    {
        id = 1;
        price = 6;
        Dégâts = 50;
        Durabilité = 25;
        ItemName = "Epée";
    }
    private void Start()
    {
       Longsword = gameObject;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Longsword.SetActive(true);
        } 
    }
}