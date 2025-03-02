using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enigme1Counter : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    private int crystals; 

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
        count.text = crystals.ToString();
    }
}
