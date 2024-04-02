using InventorySystem;
using UnityEngine;

public class Furnace : MonoBehaviour, IInteractable
{
    public RemeltingManager RemeltingManager;

    private AudioSource _audio;
    private RemeltingRecipe _handlingRecipe;
    private bool _isWorking;
    private ItemData _fuel;
    private ItemData _rawMaterial;
    private ItemData _result;
    private float _workingTime;
    private float _meltingTime;

    private void Start() => _audio = GetComponent<AudioSource>();

    private void FixedUpdate()
    {
        _workingTime -= Time.deltaTime;
        _isWorking = _workingTime > 0;
        if (_meltingTime > 0 && _isWorking) _meltingTime -= Time.deltaTime;
        Use();
    }
    
    private void Use()
    {
        try
        {
            ItemHandler fuelItem = null;
            if (FurnaceUI.Instance.FuelSlot.GetHandlingItem().GetItemData().ID != -1)
            {
                fuelItem = ItemsDataHandler.Instance.Data.items[FurnaceUI.Instance.FuelSlot.GetHandlingItem().GetItemData().ID].ItemPrefab;
            }

            ItemHandler RawMaterialItem = null;
            if (FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().GetItemData().ID != -1)
            {
                RawMaterialItem = ItemsDataHandler.Instance.Data.items[FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().GetItemData().ID].ItemPrefab;
            }

            Fuel fuel = RemeltingManager.GetFuel(fuelItem);
            if (fuel != null || _workingTime > 0)
            {
                _handlingRecipe = RemeltingManager.GetRecipe(RawMaterialItem);
                if (_handlingRecipe != null)
                {
                    if (FurnaceUI.Instance.ResultSlot.GetHandlingItem().GetItemData().ID == -1 || FurnaceUI.Instance.ResultSlot.GetHandlingItem().GetItemData().ID == _handlingRecipe.Result.itemID)
                    {
                        if (fuel != null && _workingTime < 0.5f)
                        {
                            _workingTime = fuel.BurningTime;
                            FurnaceUI.Instance.FuelSlot.GetHandlingItem().OnCountChange(-1);
                        }
                        if (_isWorking)
                        {
                            Melt();
                        }
                    }
                }
            }
            else _isWorking = false;

            if (FurnaceUI.Instance.HandlingFurnace != this) return;
            try
            {
                if (_rawMaterial != FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().GetItemData())
                {
                    _rawMaterial = FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().GetItemData();
                }

                if (_result != FurnaceUI.Instance.ResultSlot.GetHandlingItem().GetItemData())
                {
                    _result = FurnaceUI.Instance.ResultSlot.GetHandlingItem().GetItemData();
                }

                if (_fuel != FurnaceUI.Instance.FuelSlot.GetHandlingItem().GetItemData())
                {
                    _fuel = FurnaceUI.Instance.FuelSlot.GetHandlingItem().GetItemData();
                }
            }
            catch { }
            
        }
        catch { }
       
    }
    
    private void Melt()
    {
        if (_meltingTime <= 0)
        {
            _audio.Play();
            if (FurnaceUI.Instance.ResultSlot.GetHandlingItem().GetItemData().ID == -1)
            {
                FurnaceUI.Instance.ResultSlot.GetHandlingItem().SetItem(_handlingRecipe.Result.itemID);
            }
            else
            {
                FurnaceUI.Instance.ResultSlot.GetHandlingItem().OnCountChange(1);
            }

            ItemData rawMaterial = FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().GetItemData();
            if (rawMaterial.ID != -1)
            {
                FurnaceUI.Instance.RawMaterialSlot.GetHandlingItem().OnCountChange(-1);
                _meltingTime = _handlingRecipe.MeltingTime;
            }
        }
        else
        {
            _audio.Stop();
            Debug.Log("melting");
        }
    }

    public void OnInteract()
    {
        EventAggregator.QuickAccessInventoryPanelRendering.Publish();
        
        FurnaceUI.Instance.OnUIActivate(this, _fuel, _rawMaterial, _result);
    }
}