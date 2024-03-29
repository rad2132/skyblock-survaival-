using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemData
{
    public int ID;
    public int Count;
    public ItemData(int iD, int count)
    {
        ID = iD;
        Count = count;
    }
}

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform OriginalParent;
    [SerializeField] private Image _slotIcon;
    [SerializeField] private Text _itemsCounter;
    private ItemData _handlingItem;
    private InventorySlot _parentSlot;
    private int _health;

    private void Start()
    {
        _parentSlot = GetComponentInParent<InventorySlot>();
        _slotIcon = GetComponent<Image>();
        _itemsCounter = GetComponentInChildren<Text>();
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        _slotIcon.raycastTarget = false;
        OriginalParent = transform.parent;
        transform.SetParent(DragItemsPanel.Instance.transform);
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        _slotIcon.raycastTarget = true;
        transform.SetParent(OriginalParent);
    }

    public virtual void SetItem(int itemID)
    {
        if (itemID == -1)
        {
            ResetItem();
            return;
        }

        Item item = ItemsDataHandler.Instance.Data.items[itemID];
        _handlingItem = new ItemData(item.ID, 1);
        _slotIcon.sprite = item.Icon;
        _slotIcon.color = Color.white;
        _itemsCounter.text = string.Empty;
        _health = item.Health;

        if (Inventory.Instance.SelectedSlot == _parentSlot)
        {
            Inventory.Instance.AddITemInHand(ItemsDataHandler.Instance.Data.items[GetItemData().ID].ItemPrefab);
        }
    }

    public virtual void OnCountChange(int count)
    {
        if (_handlingItem == null) return;
        _handlingItem.Count += count;
        if (_handlingItem.Count == 1)
        {
            _itemsCounter.text = string.Empty;
            return;
        }
        if (_handlingItem.Count == 0)
        {
            ResetItem();
            
            return;
        }

        _itemsCounter.text = _handlingItem.Count.ToString();
    }
    public virtual void ResetItem()
    {
        if (Inventory.Instance.SelectedSlot == _parentSlot)
        {
            Inventory.Instance.AddITemInHand(null);
        }
        _handlingItem = null;
        _slotIcon.sprite = null;
        _slotIcon.color = Color.clear;
        _itemsCounter.text = string.Empty;
    }

    public void ClearItem()
    {
        ItemData data = GetItemData();
        if (data.ID == -1) return;
        
        ResetItem();
        for (int i = 0; i < data.Count; i++) Inventory.Instance.AddItem(ItemsDataHandler.Instance.Data.items[data.ID]);
    }

    public virtual ItemData GetItemData()
    {
        if (_handlingItem != null)
        {
            return _handlingItem;
        }

        ItemData dataResult = new ItemData(-1, 1);
        return dataResult;
    }

    public void Damage()
    {
        _health--;
        if (_health != 0) return;
        
        Inventory.Instance.DestroyParticle.Play();
        ResetItem();
    }
}
