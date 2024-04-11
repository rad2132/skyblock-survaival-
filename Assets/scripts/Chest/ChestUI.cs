using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public static ChestUI Instance;

    public List<InventorySlot> Slots = new();
    public ChestHandler HandlingChest { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < Slots.Count; i++)
        {
            Slots[i].SlotNumber = i;
        }
    }

    public void OnChestOpen(List<ItemData> chestItems, ChestHandler chest)
    {        
        HandlingChest = chest;
       
        for (int i = 0; i < Slots.Count; i++)
        {
            InventoryItem item = Slots[i].GetHandlingItem();
            item.SetItem(chestItems[i].ID);
            try
            {
               item.OnCountChange(chestItems[i].Count - 1);
            }
            catch { }
        }
    }
    public void OnItemChanged(int slotID)
    {
        StartCoroutine(ChangeItem(slotID));
    }
    private IEnumerator ChangeItem(int slotID)
    {
        yield return new WaitForEndOfFrame();

        HandlingChest.OnItemChange(slotID, Slots[slotID].GetHandlingItem().GetItemData());
    }
}
