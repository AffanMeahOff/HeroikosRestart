using UnityEngine;
using TMPro;  // Pour TextMeshPro

public class Interface : argent
{
    public TextMeshProUGUI DrachmesText;
    
    void Start()
    {
        base.Start();
        UpdateUI();     // Mettre à jour l'UI dès le début
    }

    // mise à jour le texte de l'UI avec le montant actuel
    void UpdateUI()
    {
        DrachmesText.text = "Drachmes : " + Montant.ToString();
    }

    // Gagner des Drachmes et mettre à jour l'UI
    public new void GagnerDrachmes(int valeur)
    {
        base.GagnerDrachmes(valeur);
        UpdateUI();  // Mise à jour l'UI après un gain
    }

   
    public new void PayerDrachmes(int valeur)
    {
        if (base.PayerDrachmes(valeur))
        {
            UpdateUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.m))
        {
            ModifierDrachmes(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ModifierDrachmes(-1);
        }
    }

    public void ModifierDrachmes(int valeur)
    {
        montant += valeur;
        UpdateUI();
    }
}