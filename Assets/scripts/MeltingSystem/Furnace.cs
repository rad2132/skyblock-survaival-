using UnityEngine;

public class Furnace : MonoBehaviour, IInteractable
{
    public InventorySlot RawMaterialSlot;
    public InventorySlot FuelSlot;
    public RemeltingResultSlot ResultSlot;
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
            if (FuelSlot.GetHandlingItem().GetItemData().ID != -1)
            {
                fuelItem = ItemsDataHandler.Instance.Data.items[FuelSlot.GetHandlingItem().GetItemData().ID].ItemPrefab;
            }

            ItemHandler RawMaterialItem = null;
            if (RawMaterialSlot.GetHandlingItem().GetItemData().ID != -1)
            {
                RawMaterialItem = ItemsDataHandler.Instance.Data.items[RawMaterialSlot.GetHandlingItem().GetItemData().ID].ItemPrefab;
            }

            Fuel fuel = RemeltingManager.GetFuel(fuelItem);
            if (fuel != null || _workingTime > 0)
            {
                _handlingRecipe = RemeltingManager.GetRecipe(RawMaterialItem);
                if (_handlingRecipe != null)
                {
                    if (ResultSlot.GetHandlingItem().GetItemData().ID == -1 || ResultSlot.GetHandlingItem().GetItemData().ID == _handlingRecipe.Result.itemID)
                    {
                        if (fuel != null && _workingTime < 0.5f)
                        {
                            _workingTime = fuel.BurningTime;
                            FuelSlot.GetHandlingItem().OnCountChange(-1);
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
                if (_rawMaterial != RawMaterialSlot.GetHandlingItem().GetItemData())
                {
                    _rawMaterial = RawMaterialSlot.GetHandlingItem().GetItemData();
                }

                if (_result != ResultSlot.GetHandlingItem().GetItemData())
                {
                    _result = ResultSlot.GetHandlingItem().GetItemData();
                }

                if (_fuel != FuelSlot.GetHandlingItem().GetItemData())
                {
                    _fuel = FuelSlot.GetHandlingItem().GetItemData();
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
            if (ResultSlot.GetHandlingItem().GetItemData().ID == -1)
            {
                ResultSlot.GetHandlingItem().SetItem(_handlingRecipe.Result.itemID);
            }
            else
            {
                ResultSlot.GetHandlingItem().OnCountChange(1);
            }

            ItemData rawMaterial = RawMaterialSlot.GetHandlingItem().GetItemData();
            if (rawMaterial.ID != -1)
            {
                RawMaterialSlot.GetHandlingItem().OnCountChange(-1);
                _meltingTime = _handlingRecipe.MeltingTime;
            }
        }
        else
        {
            _audio.Stop();
            Debug.Log("melting");
        }
    }

    public void OnInteract() => FurnaceUI.Instance.OnUIActivate(this, _fuel, _rawMaterial, _result);
}