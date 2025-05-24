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
    private bool hasrotated = false;
    private bool hasmoved = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
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

        if (Input.GetKey(KeyCode.Mouse1) && epee.activeSelf) EnterBlockingStance();
        else ExitBlockingStance();

    }

    void EnterBlockingStance()
    {
        if (!hasrotated)
        {
            epee.transform.localRotation = Quaternion.Euler(-90f, -9.5f, -77.5f);
            hasrotated = true;
        }
        if (!hasmoved)
        {
            epee.transform.localPosition = new Vector3(-0.75f, 0.9f, 2.5f);
            hasmoved = true;
        }
        isBlocking = true;
        Debug.Log("Blocking");
    }

    void ExitBlockingStance()
    {
        if (hasrotated)
        {
            epee.transform.localRotation = originalRotation;
            hasrotated = false;
        }
        if (hasmoved)
        {
            epee.transform.localPosition = originalPosition;
            hasmoved = false;
        }
        isBlocking = false;
    }
    public bool GetBlocking()
    {
        return isBlocking;
    }
    public void Start()
    {
        Counter = FindAnyObjectByType<Enigme1Counter>();
        epee.SetActive(false);
        originalPosition = epee.transform.localPosition;
        originalRotation = epee.transform.localRotation;
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
