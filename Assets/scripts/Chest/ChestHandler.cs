using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour, IInteractable
{
    private List<ItemData> _items = new List<ItemData>();
    [SerializeField] private Animator _animator;
    private void Awake()
    {
     StartCoroutine(OnAwake());   
    }
    private IEnumerator OnAwake()
    {
        yield return new WaitForEndOfFrame();

        for (int i = 0; i < ChestUI.Instance.Slots.Count; i++)
        {
            _items.Add(new ItemData(-1, 1));
        }
    }
    public void OnInteract()
    {
       StartCoroutine(OpenChest());
    }

    private IEnumerator OpenChest()
    {
        _animator.SetBool("Open", true);
        ChestUI.Instance.OnChestOpen(_items, this);
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false, false, true,false);
        yield return new WaitForEndOfFrame();
        _animator.SetBool("Open", false);
    }

    public void OnItemChange(int slotNumber,ItemData newItemData)
    {
        Debug.Log("chest item changed");
        _items[slotNumber].ID = newItemData.ID;
        _items[slotNumber].Count = newItemData.Count;
    }
}
