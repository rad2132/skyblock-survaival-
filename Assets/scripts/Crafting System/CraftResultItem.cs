using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftResultItem : InventoryItem
{
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (GetItemData().ID != -1)
        {
            Workbench.Instance.OnItemCreated();
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }

    public override ItemData GetItemData()
    {
        return base.GetItemData();
    }

    public override void OnCountChange(int count)
    {
        base.OnCountChange(count);
    }

    public override void SetItem(int itemID)
    {
        base.SetItem(itemID);
    }

    public override void ResetItem()
    {
        base.ResetItem();
    }
}
