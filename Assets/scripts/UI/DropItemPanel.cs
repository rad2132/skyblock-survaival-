using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemPanel : MonoBehaviour, IDropHandler
{
    public Transform ItemSpawner;
    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (item != null && item.GetItemData().ID != -1)
        {
            Item itemReference = ItemsDataHandler.Instance.Data.items[item.GetItemData().ID];
            int countToSpawn = item.GetItemData().Count;

            itemReference.ItemPrefab.DropOnAwake = true;
            for (int i = countToSpawn; i > 0; i--)
            {
                Transform spawnedItem = Instantiate(itemReference.ItemPrefab.transform, ItemSpawner.position, Quaternion.identity);
                spawnedItem.localScale = Vector3.one * 0.3f;
            }
            itemReference.ItemPrefab.DropOnAwake = false;
            item.ResetItem();
        }
    }
}
