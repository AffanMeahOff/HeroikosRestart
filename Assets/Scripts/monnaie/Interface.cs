using UnityEngine;
using TMPro;

public class Interface : argent
{
    public TextMeshProUGUI DrachmesText;

    private void Start()
    {
        // Appeler explicitement la méthode d'initialisation
        InitialiserMontant();
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (DrachmesText != null)
        {
            DrachmesText.text = "Drachmes : " + Montant.ToString();
        }
        else
        {
            Debug.LogWarning("TextMeshProUGUI n'est pas assigné dans l'inspecteur.");
        }
    }

    public void ModifierDrachmes(int valeur)
    {
        GagnerDrachmes(valeur);
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ModifierDrachmes(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ModifierDrachmes(-1);
        }
    }
}