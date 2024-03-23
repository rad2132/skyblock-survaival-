using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public Transform Hand;
    public List<InventorySlot> QuickAccessPanel;
    public List<InventorySlot> GeneralInventory;
    public InventorySlot SelectedSlot;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SelectedSlot = QuickAccessPanel[0];
    }

    public void SelectSlot(int slotNumber)
    {
        SelectedSlot = QuickAccessPanel[slotNumber - 1];
        int id = SelectedSlot.GetHandlingItem().GetItemData().ID;
        if (id == -1)
        {
            AddITemInHand(null);
        }
        else
        {
            AddITemInHand(ItemsDataHandler.Instance.Data.items[id].ItemPrefab);
        }

        
    }

    public bool AddItem(Item item)
    {
        if (item.ItemType == ItemType.Tool || item.StackSize == 1)
        {
            foreach (InventorySlot slot in QuickAccessPanel)
            {
                InventoryItem invItem = slot.GetHandlingItem();

                if (invItem.GetItemData().ID == -1)
                {
                    invItem.SetItem(item.ID);
                    return true;
                }
            }

            foreach (InventorySlot slot in GeneralInventory)
            {
                InventoryItem invItem = slot.GetHandlingItem();

                if (invItem.GetItemData().ID == -1)
                {
                    invItem.SetItem(item.ID);
                    return true;
                }
            }
        }


        List<InventorySlot> slots = new List<InventorySlot>();


        foreach (InventorySlot slot in QuickAccessPanel)
        {
            slots.Add(slot);
        }

        foreach (InventorySlot slot in GeneralInventory)
        {
            slots.Add(slot);
        }

        foreach (InventorySlot slot in slots)
        {
            InventoryItem invItem = slot.GetHandlingItem();
            if (invItem.GetItemData() != null && invItem.GetItemData().ID == item.ID && invItem.GetItemData().Count < item.StackSize)
            {
                invItem.OnCountChange(1);
                return true;
            }
        }

        foreach (InventorySlot slot in slots)
        {
            InventoryItem invItem = slot.GetHandlingItem();
            if (invItem.GetItemData().ID == -1)
            {
                invItem.SetItem(item.ID);
                return true;
            }
        }

        return false;
    }

    public void AddITemInHand(ItemHandler itemPrefab)
    {  if(Hand.childCount == 1)
        {
            Destroy(Hand.GetChild(0).gameObject);
        }

        if (itemPrefab == null) return;
        Transform clone = Instantiate(itemPrefab.transform, Hand);
        try
        {
            clone.GetComponent<Rigidbody>().isKinematic = true;
            List<Collider> colliders = clone.GetComponents<Collider>().ToList();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
            clone.gameObject.layer = Hand.gameObject.layer;
        }
        catch { }
    }
}
