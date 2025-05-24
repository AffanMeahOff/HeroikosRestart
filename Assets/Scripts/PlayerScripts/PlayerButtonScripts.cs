using System.Numerics;
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
    private bool isBlocking;
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
        if (Input.GetKeyDown(KeyCode.Mouse1) && swordOn && epee.activeSelf)
        {
            epee.transform.Rotate(new UnityEngine.Vector3(-90, -9.5f, -77.5f));
            epee.transform.position = new UnityEngine.Vector3(-0.5f, 0.9f, 2.5f);
            isBlocking = true;
        }
        else
        {
            epee.transform.Rotate(new UnityEngine.Vector3(30, -45f, 0));
            epee.transform.position = new UnityEngine.Vector3(0, 0, 2.4f);
            isBlocking = false;
        }
        
    }
    public bool GetBlocking()
    {
        return isBlocking;
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
