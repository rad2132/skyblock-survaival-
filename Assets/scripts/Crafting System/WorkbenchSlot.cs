using UnityEngine.EventSystems;
public class WorkbenchSlot : InventorySlot
{
    public InventoryItem InventoryItem;
    public override void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.OriginalParent = transform;
        }
        else
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem coreItem = transform.GetComponentInChildren<InventoryItem>();
            coreItem.OriginalParent = inventoryItem.OriginalParent;
            coreItem.transform.SetParent(coreItem.OriginalParent);
            inventoryItem.OriginalParent = transform;
            InventoryItem = inventoryItem;
        }
        Workbench.Instance.OnCraftTry();
    }
    public override InventoryItem GetHandlingItem()
    {
       return InventoryItem;
    }
}
