using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

public class ChestHandler : MonoBehaviour, IInteractable
{
    private List<ItemData> _items = new();  
    [SerializeField] private Animator _animator;
    
    private void Awake() => StartCoroutine(OnAwake());

    private IEnumerator OnAwake()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < ChestUI.Instance.Slots.Count; i++) _items.Add(new ItemData(-1, 1));
       
    }
    public void OnInteract()
    {
        ChestUI.Instance.OnChestOpen(_items, this);
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false, false, true,false);
        _animator.SetTrigger("Open");        
        EventAggregator.QuickAccessInventoryChestPanelRendering.Publish();
       // EventAggregator.QuickAccessInventoryPanelRendering.Publish();
    }

    public void OnItemChange(int slotNumber,ItemData newItemData)
    {
        Debug.Log("chest item changed");
        int newItemID = newItemData.ID;
        _items[slotNumber].ID = newItemID;
        _items[slotNumber].Count = newItemData.Count;     
        if (newItemID >=0) 
        {
            Inventory.Instance.RemoveItem(ItemsDataHandler.Instance.Data.items[newItemID]);
        }
    }
}
