using UnityEngine;

public class argent : MonoBehaviour
{
    private int montant; // Utilisation de private pour un meilleur encapsulage

    public int Montant => montant; // Propriété publique pour accéder au montant

    // Nouvelle méthode d'initialisation
    protected void InitialiserMontant()
    {
        montant = 0;
        Debug.Log("Bienvenue dans l'âge d'or des Drachmes ! Montant initialisé à " + montant + " Drachmes.");
    }

    public void GagnerDrachmes(int valeur)
    {
        if (valeur > 0)
        {
            montant += valeur;
            Debug.Log($"Vous avez gagné {valeur} Drachmes. Total : {montant} Drachmes.");
        }
        else
        {
            Debug.LogWarning("Impossible de gagner une valeur négative ou nulle.");
        }
    }

    public bool PayerDrachmes(int valeur)
    {
        if (PeutPayer(valeur))
        {
            montant -= valeur;
            Debug.Log($"Vous avez payé {valeur} Drachmes. Nouveau total : {montant} Drachmes.");
            return true;
        }
        else
        {
            Debug.LogWarning($"Fonds insuffisants ! Vous avez seulement {montant} Drachmes.");
            return false;
        }
    }

    private bool PeutPayer(int valeur)
    {
        return montant >= valeur;
    }
}
