using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Epee : Item
{
    
    public GameObject Longsword;
    private void Awake()
    {
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