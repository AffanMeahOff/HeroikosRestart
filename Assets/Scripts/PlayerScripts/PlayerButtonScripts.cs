using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonScripts : MonoBehaviour
{
    [SerializeField] private GameObject epee;
    [SerializeField] private bool swordOn = false;
    public InventaireManager inventory;
    private Enigme1Counter Counter;

    [SerializeField] Enigme1Manager enigme1Manager;
    public InventaireUI left_UI; 
    public GameObject inventorySlotPrefab;
    public Transform inventoryPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("added 9");
            Counter.collected += 9;
        }
        swordOn = enigme1Manager != null && enigme1Manager.hehasfinished;
        if (Input.GetKeyDown(KeyCode.F) && swordOn)
        {
            epee.SetActive(!epee.activeSelf);
            UpdateUI();
        }
        
    }
    public void Start()
    {
        Counter = FindAnyObjectByType<Enigme1Counter>();
        epee.SetActive(false);
        UpdateUI();
    }

    public void UpdateUI()
    {
        foreach (Transform child in inventoryPanel)
        {
            if (child.gameObject != inventorySlotPrefab) // Ne pas détruire l'original
            {
                Destroy(child.gameObject);
            }
        }
        ItemData item = epee.GetComponent<ItemData>();
        if (!epee.activeSelf)
        {

            if (inventory.AddItem(item, 1)) // Ajoute l'épée à l'inventaire
            {
                left_UI.UpdateUI();
            }
        }
        else
        {
            inventory.RemoveItem(item);
            left_UI.UpdateUI();
            GameObject slot = Instantiate(inventorySlotPrefab, inventoryPanel);
            slot.transform.GetComponentInChildren<Image>().sprite = item.icon;
        }
    }
}
