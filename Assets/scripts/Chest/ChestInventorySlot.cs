using UnityEngine.EventSystems;
public class ChestInventorySlot : InventorySlot
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        ChestUI.Instance.OnItemChanged(SlotNumber);
    }
    public override void OnItemChanged(InventoryItem item)
    {
        ChestUI.Instance.OnItemChanged(SlotNumber);
    }
    public override InventoryItem GetHandlingItem()
    {
        return base.GetHandlingItem();
    }
}
