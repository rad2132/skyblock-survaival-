using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CraftingSystem
{
    public class CraftBook : MonoBehaviour
    {
        [SerializeField] private Workbench2x2 _workbench2X2;
        [SerializeField] private Workbench3x3 _workbench3X3;
        
        public void SetRecipe2x2(Recipe recipe)
        {
            List<InventoryItem> items = new (Inventory.Instance.QuickAccessPanel.Select(t => t.GetHandlingItem()));
            items.AddRange(Inventory.Instance.GeneralInventory.Select(t => t.GetHandlingItem()));
            
            if (recipe.UpperLeftItemId() != -1) { if (!TrySetResource(items, recipe.UpperLeft.itemID, _workbench3X3.UpperLeft.InventoryItem)) return; }
            else _workbench3X3.UpperLeft.InventoryItem.ClearItem();

            if (recipe.UpperRightItemId() != -1) { if (!TrySetResource(items, recipe.UpperRight.itemID, _workbench3X3.UpperRight.InventoryItem)) return; }
            else _workbench3X3.UpperRight.InventoryItem.ClearItem();
            //=============================================================================================================================================
            if (recipe.LowerLeftItemId() != -1) { if (!TrySetResource(items, recipe.LowerLeft.itemID, _workbench3X3.LowerLeft.InventoryItem)) return; }
            else _workbench3X3.LowerLeft.InventoryItem.ClearItem();

            if (recipe.LowerRightItemId() != -1) { if (!TrySetResource(items, recipe.LowerRight.itemID, _workbench3X3.UpperRight.InventoryItem)) return; }
            else _workbench3X3.LowerRight.InventoryItem.ClearItem();
        } 
        
        public void SetRecipe3x3(Recipe recipe)
        {
            List<InventoryItem> items = new (Inventory.Instance.QuickAccessPanel.Select(t => t.GetHandlingItem()));
            items.AddRange(Inventory.Instance.GeneralInventory.Select(t => t.GetHandlingItem()));

            if (recipe.UpperLeftItemId() != -1) { if (!TrySetResource(items, recipe.UpperLeft.itemID, _workbench3X3.UpperLeft.InventoryItem)) return; }
            else _workbench3X3.UpperLeft.InventoryItem.ClearItem();

            if (recipe.UpperCenterItemId() != -1) { if (!TrySetResource(items, recipe.UpperCenter.itemID, _workbench3X3.UpperCenter.InventoryItem)) return; }
            else _workbench3X3.UpperCenter.InventoryItem.ClearItem();

            if (recipe.UpperRightItemId() != -1) { if (!TrySetResource(items, recipe.UpperRight.itemID, _workbench3X3.UpperRight.InventoryItem)) return; }
            else _workbench3X3.UpperRight.InventoryItem.ClearItem();
            //==================================================================================================================================================
            if (recipe.MiddleLeftItemId() != -1) { if (!TrySetResource(items, recipe.MiddleLeft.itemID, _workbench3X3.MiddleLeft.InventoryItem)) return; }
            else _workbench3X3.MiddleLeft.InventoryItem.ClearItem();

            if (recipe.MiddleCenterItemId() != -1) { if (!TrySetResource(items, recipe.MiddleCenter.itemID, _workbench3X3.MiddleCenter.InventoryItem)) return; }
            else _workbench3X3.MiddleCenter.InventoryItem.ClearItem();

            if (recipe.MiddleRightItemId() != -1) { if (!TrySetResource(items, recipe.MiddleRight.itemID, _workbench3X3.MiddleRight.InventoryItem)) return; }
            else _workbench3X3.MiddleRight.InventoryItem.ClearItem();
            //==================================================================================================================================================
            if (recipe.LowerLeftItemId() != -1) { if (!TrySetResource(items, recipe.LowerLeft.itemID, _workbench3X3.LowerLeft.InventoryItem)) return; }
            else _workbench3X3.LowerLeft.InventoryItem.ClearItem();

            if (recipe.LowerCenterItemId() != -1) { if (!TrySetResource(items, recipe.LowerCenter.itemID, _workbench3X3.LowerCenter.InventoryItem)) return; }
            else _workbench3X3.LowerCenter.InventoryItem.ClearItem();

            if (recipe.LowerRightItemId() != -1) { if (!TrySetResource(items, recipe.LowerRight.itemID, _workbench3X3.UpperRight.InventoryItem)) return; }
            else _workbench3X3.LowerRight.InventoryItem.ClearItem();
            
            Workbench.Instance.TryCraft();
        }

        private bool TrySetResource(List<InventoryItem> items, int recipeItemId, InventoryItem inventoryItem)
        {
            var item = items.AsParallel().FirstOrDefault(x => x.GetItemData().ID == recipeItemId);
            if (item == null)
            {
                inventoryItem.ClearItem();
                return false;
            }
                
            inventoryItem.ClearItem();
            item.OnCountChange(-1);
            inventoryItem.SetItem(recipeItemId);
            return true;
        }
    }
}