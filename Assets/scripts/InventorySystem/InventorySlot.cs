using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public int SlotNumber;
    public virtual void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            newItem.OriginalParent = transform;
        }
        else
        {
            InventoryItem newItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem coreItem = transform.GetComponentInChildren<InventoryItem>();
            if(coreItem != null)
            {
                int newItemID = newItem.GetItemData().ID;
                int newItemCount = newItem.GetItemData().Count-1;
                int coreItemID = coreItem.GetItemData().ID;
                int coreItemCount = coreItem.GetItemData().Count-1;

                coreItem.SetItem(newItemID);
                for (int i = newItemCount; i > 0; i--) 
                {
                    coreItem.OnCountChange(1);
                }

                newItem.SetItem(coreItemID);
                for (int i = coreItemCount; i > 0; i--)
                {
                    newItem.OnCountChange(1);
                }

            }
        }
    }

    public virtual InventoryItem GetHandlingItem()
    {
        return transform.GetComponentInChildren<InventoryItem>();
    }
}
