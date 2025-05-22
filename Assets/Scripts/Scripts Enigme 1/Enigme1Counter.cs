using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enigme1Counter : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    private int crystals; 

    public bool enigme1Finished;

    private void Start()
    {
        if (count != null && int.TryParse(count.text, out crystals))
        {
            Debug.Log("Nombre de crystaux : " + crystals);
        }
        else
        {
            Debug.LogWarning("Impossible");
            crystals = 0; 
        }
    }
    private void Awake()        
    {
        UpdateHUD();
    }

    private void Update()
    {
        if (count != null && int.TryParse(count.text, out crystals))
        {
        }
    
        enigme1Finished = collected >= 1;
        
    }


    public int collected {
        get {
            return crystals;
        }
        set {
            
            crystals = value;
            
            UpdateHUD();
        }
    }
    
    private void UpdateHUD()
    {
        Debug.Log("Count text = " + count.text);
        Debug.Log("Crystals = " + collected);
        count.text = collected.ToString();
    }
}
