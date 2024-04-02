using System;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class QuickAccessInventoryPanelView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> QuickAccessInventoryPanelSlots;

        private void Awake()
        {
            EventAggregator.QuickAccessInventoryPanelRendering.Subscribe(OnQuickAccessInventoryPanelRendering);
        }

        public void OnQuickAccessInventoryPanelRendering()
        {
            for (var i = 0; i < QuickAccessInventoryPanelSlots.Count; i++)
            {
                var inventoryItem = QuickAccessInventoryPanelSlots[i].GetComponentInChildren<InventoryItem>();
                inventoryItem.SetItem(Inventory.Instance.QuickAccessPanel[i].GetHandlingItem().GetItemData().ID);
            }
        }
    }
}