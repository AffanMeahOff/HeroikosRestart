[System.Serializable]
public class InventaireItem
{
    public ItemData item;
    public int quantity;

    public InventaireItem(ItemData item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }
}
