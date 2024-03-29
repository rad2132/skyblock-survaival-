using UnityEngine.EventSystems;

public class CraftResultItem : InventoryItem
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (GetItemData().ID != -1) Workbench.Instance.OnItemCreated();
    }
}