using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBlockHandler : MonoBehaviour
{
    public int MinLifeTime = 30;
    public int MaxLifeTime = 120;
    [SerializeField] private List<ItemDrop> itemDrops = new();
    private bool isDropped = false;

    private void Awake()
    {
        if (isDropped)
        {
            OnLogDrop();
        }
    }
    public void OnLogDrop()
    {
        StartCoroutine(OnTreeBroken());
    }
    private IEnumerator OnTreeBroken()
    {
        int lifetime = Random.Range(MinLifeTime, MaxLifeTime);
        yield return new WaitForSeconds(lifetime);

        ItemHandler itemPrefab = SelectItem();
        if (itemPrefab != null)
        {
            ItemHandler drop = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            drop.OnDrop();
        }
        Destroy(gameObject);
    }

    private ItemHandler SelectItem()
    {
        float randomValue = Random.Range(0f, 1f);
        float currentItemValue = 0f;

        foreach (ItemDrop itemDrop in itemDrops)
        {
            currentItemValue += itemDrop.Probability;
            if (randomValue <= currentItemValue)
            {
                return itemDrop.Item;
            }
        }

        return null;
    }
}
