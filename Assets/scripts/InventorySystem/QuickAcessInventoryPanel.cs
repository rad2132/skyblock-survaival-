using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class QuickAccessInventoryPanelView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _quickAccessInventoryPanelSlots;
        [SerializeField] private List<GameObject> _quickAccessInventoryChestPanelSlots;

        private void Awake()
        {
            EventAggregator.QuickAccessInventoryPanelRendering.Subscribe(OnQuickAccessInventoryPanelRendering);
            EventAggregator.QuickAccessInventoryChestPanelRendering.Subscribe(OnQuickAccessInventoryChestPanelRendering);
        }
        
        private void OnDisable()
        {
            EventAggregator.QuickAccessInventoryPanelRendering.Unsubscribe(OnQuickAccessInventoryPanelRendering);
            EventAggregator.QuickAccessInventoryChestPanelRendering.Unsubscribe(OnQuickAccessInventoryChestPanelRendering);
        }

        public void OnQuickAccessInventoryPanelRendering()
        {
            for (var i = 0; i < _quickAccessInventoryPanelSlots.Count; i++)
            {
                var inventoryItem = _quickAccessInventoryPanelSlots[i].GetComponentInChildren<InventoryItem>();
                inventoryItem.SetItem(Inventory.Instance.QuickAccessPanel[i].GetHandlingItem().GetItemData().ID);
            }
        }

        public void OnQuickAccessInventoryChestPanelRendering()
        {
            for (var i = 0; i < _quickAccessInventoryChestPanelSlots.Count; i++)
            {
                var inventoryItem = _quickAccessInventoryChestPanelSlots[i].GetComponentInChildren<InventoryItem>();
                inventoryItem.SetItem(Inventory.Instance.QuickAccessPanel[i].GetHandlingItem().GetItemData().ID);
            }
        }
    }
}