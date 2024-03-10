using UnityEngine;
using UnityEngine.EventSystems;

public class RemeltingResultSlot : InventorySlot
{
    public override void OnDrop(PointerEventData eventData)
    {
        Debug.Log("You can't drop items here");
    }
}
