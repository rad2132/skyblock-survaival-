using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public float RotateSpeed = 5f;
    public int DroppedItemsLayerNumber = 7;
    public bool isAlive { get; private set; } = true;
    public bool DropOnAwake;
    public int itemID;
    public Collider triggerBox;
    public ItemHandler DroppedItemPrefab;
    protected virtual void Awake()
    {
        enabled = false;
        if (DropOnAwake)
        {
            OnDrop();
        }
        else triggerBox.enabled = false;

    }
    protected virtual void FixedUpdate()
    {
        transform.Rotate(0f, RotateSpeed, 0f);
    }

    public virtual void OnDrop()
    {
        try { GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop(); } catch { }
        enabled = true;
        isAlive = false;
        triggerBox.enabled = true;
        transform.localScale = new Vector3(.3f, .3f, .3f);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        transform.position += new Vector3(1, 0, 1) * Random.Range(-0.3f, 0.3f);
        gameObject.layer = DroppedItemsLayerNumber;
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player" || isAlive || !enabled) return;

        Inventory playerInventory = Inventory.Instance;
        Item referenceItem = ItemsDataHandler.Instance.Data.items[itemID];

        if (playerInventory.AddItem(referenceItem)) Destroy(gameObject);
    }
}
