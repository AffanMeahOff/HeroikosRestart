using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemData itemData; // Objet ramassable
    public int quantity = 1;
    
    public InventaireManager inventory;


    public InventaireUI UI;
    
    private bool isPlayerNearby = false; // Indique si le joueur est proche


    void Start()
    {
        inventory = FindObjectOfType<InventaireManager>();
        if (inventory == null) // Vérifie si Inventory est déjà assigné
        {
            inventory = FindFirstObjectByType<InventaireManager>(); // Trouve l'inventaire dans la scène
        }

        if (inventory == null)
        {
            Debug.LogError("❌ Aucun Inventory trouvé dans la scène !");
        }
        else
        {
            Debug.Log($"✅ Inventory trouvé : {inventory.name}");
        }

        if (UI == null) // Vérifie si UI est déjà assigné
        {
            UI = FindFirstObjectByType<InventaireUI>(); // Trouve l'inventaire dans la scène
        }

        if (UI == null)
        {
            Debug.LogError("❌ Aucun UI trouvé dans la scène !");
        }
        else
        {
            Debug.Log($"✅ UI trouvé : {UI.name}");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("🔹 Joueur détecté près de " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("🔹 Joueur trop loin !");
        }
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("🔹 Touche P pressée !");

            if (isPlayerNearby)
            {
                if (itemData == null)
                {
                    Debug.LogWarning("❌ Aucun ItemData assigné à " + gameObject.name);
                    return;
                }
                
                if (inventory != null && inventory.AddItem(itemData, quantity))
                {
                    Debug.Log($"✅ {itemData.itemName} ramassé !");
                    UI.UpdateUI();
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("❌ Trop loin pour ramasser !");
            }
        }
    }




}
