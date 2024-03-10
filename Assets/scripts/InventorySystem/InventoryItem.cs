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
    [HideInInspector]
    public Transform OriginalParent;
    private ItemData _handlingItem;
    [SerializeField]
    private Image _slotIcon;
    [SerializeField]
    private Text _itemsCounter;
    private InventorySlot _parentSlot;

    private void Start()
    {
        _parentSlot = GetComponentInParent<InventorySlot>();
        _slotIcon = GetComponent<Image>();
        _itemsCounter = GetComponentInChildren<Text>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _slotIcon.raycastTarget = false;
        OriginalParent = transform.parent;
        transform.SetParent(DragItemsPanel.Instance.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _slotIcon.raycastTarget = true;
        transform.SetParent(OriginalParent);
    }

    public void SetItem(int itemID)
    {
        if (itemID == -1)
        {
            ResetItem();
            return;
        }

        Item item = ItemsDataHandler.Instance.Data.items[itemID];

        _handlingItem = new ItemData(item.ID, 1);
        _slotIcon.sprite = item.Icon;
        _itemsCounter.text = string.Empty;

        if (Inventory.Instance.SelectedSlot == _parentSlot)
        {
            Inventory.Instance.AddITemInHand(ItemsDataHandler.Instance.Data.items[GetItemData().ID].ItemPrefab);
        }
    }

    public void OnCountChange(int count)
    {
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
    public void ResetItem()
    {
        if (Inventory.Instance.SelectedSlot == _parentSlot)
        {
            Inventory.Instance.AddITemInHand(null);
        }
        _handlingItem = null;
        _slotIcon.sprite = null;
        _itemsCounter.text = string.Empty;
    }

    public ItemData GetItemData()
    {
        if (_handlingItem != null)
        {
            return _handlingItem;
        }

        ItemData dataResult = new ItemData(-1, 1);
        return dataResult;

    }
}
