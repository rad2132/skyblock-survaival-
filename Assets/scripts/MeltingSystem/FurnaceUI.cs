using UnityEngine;

public class FurnaceUI : MonoBehaviour
{
    public static FurnaceUI Instance;

    public InventorySlot FuelSlot;
    public InventorySlot RawMaterialSlot;
    public InventorySlot ResultSlot;

    public Furnace HandlingFurnace {  get; private set; }
    
    private void Awake() => Instance = this;

    public void OnUIActivate(Furnace furnace, ItemData fuel,ItemData rawMaterial,ItemData result)
    {
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false,false,false,true);
        HandlingFurnace = furnace;
        if(fuel!= null && fuel.ID!= -1)
        {
            FuelSlot.GetHandlingItem().SetItem(fuel.ID);
            FuelSlot.GetHandlingItem().OnCountChange(fuel.Count-1);
        }
        else FuelSlot.GetHandlingItem().ResetItem();

        if(rawMaterial!= null && rawMaterial.ID!= -1)
        {
            RawMaterialSlot.GetHandlingItem().SetItem(rawMaterial.ID);
            RawMaterialSlot.GetHandlingItem().OnCountChange(rawMaterial.Count-1);
        }
        else
        {
            RawMaterialSlot.GetHandlingItem().ResetItem();
        }

        if(result!= null && result.ID!= -1)
        {
            ResultSlot.GetHandlingItem().SetItem(result.ID);
            ResultSlot.GetHandlingItem().OnCountChange(result.Count - 1);
        }
        else ResultSlot.GetHandlingItem().ResetItem();
    }
}
