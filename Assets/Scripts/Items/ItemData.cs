using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : MonoBehaviour
{
    public string itemName;
    public Sprite icon;
    public int maxStack;
}
