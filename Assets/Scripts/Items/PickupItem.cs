using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemData itemData; // Objet ramassable
    public int quantity = 1;

    private bool isPlayerNearby = false; // Indique si le joueur est proche

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
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.P))
        {
            if (itemData == null)
            {
                Debug.LogWarning("❌ Aucun ItemData assigné à " + gameObject.name);
                return;
            }

            InventaireManager inventory = FindAnyObjectByType<InventaireManager>();
            if (inventory != null && inventory.AddItem(itemData, quantity))
            {
                Debug.Log($"✅ {itemData.itemName} ramassé et ajouté à l’inventaire !");
                FindAnyObjectByType<InventaireUI>().UpdateUI();
                Destroy(gameObject);
            }
        }
    }



}
