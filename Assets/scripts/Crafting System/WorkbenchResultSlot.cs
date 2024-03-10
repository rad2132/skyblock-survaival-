using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkbenchResultSlot : InventorySlot
{
    public override void OnDrop(PointerEventData eventData)
    {
        Debug.Log("unable to put item into result slot");
    }
}
