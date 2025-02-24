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
            Debug.Log("🔹 Appuyez sur P pour ramasser " + itemData.itemName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.P))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            InventaireManager inventory = player.GetComponent<InventaireManager>();

            if (inventory != null && inventory.AddItem(itemData, quantity))
            {
                Destroy(gameObject); // Supprime l'objet après ramassage
            }
        }
    }


}
