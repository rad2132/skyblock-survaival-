using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int SlotNumber;
    public virtual void OnDrop(PointerEventData eventData)
    {
        try
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventorySlot otherSlot = newItem.OriginalParent.GetComponent<InventorySlot>();
            InventoryItem coreItem = transform.GetComponentInChildren<InventoryItem>();

            if (transform.childCount == 0)
            {
                newItem.OriginalParent = transform;
            }
            else
            {
                if (coreItem != null)
                {
                    int newItemID = newItem.GetItemData().ID;
                    int newItemCount = newItem.GetItemData().Count - 1;
                    int coreItemID = coreItem.GetItemData().ID;
                    int coreItemCount = coreItem.GetItemData().Count - 1;

                    coreItem.SetItem(newItemID);
                    coreItem.OnCountChange(newItemCount);

                    newItem.SetItem(coreItemID);
                    newItem.OnCountChange(coreItemCount);
                }
            }
            coreItem.OriginalParent = otherSlot.transform;
            otherSlot.OnItemChanged(coreItem);
        }
        catch { }
    }
    public virtual void OnItemChanged(InventoryItem item)
    {
    }
    public virtual InventoryItem GetHandlingItem() => transform.GetComponentInChildren<InventoryItem>();
}
