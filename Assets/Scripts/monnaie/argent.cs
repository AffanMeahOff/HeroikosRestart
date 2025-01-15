using UnityEngine;

public class argent : MonoBehaviour
{
    private int montant;

    public int Montant
    {
        get{return montant;}
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        montant = 0;
        Debug.Log("Bienvenue dans l'âge d'or des Drachmes ! Commencer à construire votre histoire avec" + montant + "Drachme(s).");
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
           Debug.Log($"Vous avez payé {valeur} Drachme(s). Nouveau total : {montant} Drachmes."); 
           return true;
       }
       else 
       { 
           Debug.LogWarning($"Fonds insuffisants ! Vous avez seulement {montant} Drachme(s)."); 
           return false; 
       }
      
    }
    
    private bool PeutPayer(int valeur)
    {
        return montant >= valeur;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
