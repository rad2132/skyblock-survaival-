using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafBlockHandler : MonoBehaviour
{
    public int MinLifeTime = 30;
    public int MaxLifeTime = 120;
    public List<ItemHandler> dropItems = new List<ItemHandler>();
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
        int dropNumber = Random.Range(0, dropItems.Count);
        yield return new WaitForSeconds(lifetime);
        ItemHandler drop = Instantiate(dropItems[dropNumber],transform.position,Quaternion.identity);
        drop.OnDrop();
        Destroy(gameObject);
    }
}
