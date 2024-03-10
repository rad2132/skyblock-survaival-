using System.Collections.Generic;
using UnityEngine;
public class PlayerActionsHandler : MonoBehaviour
{
    private ItemsDataManager _itemsManager;
    public LayerMask EnemiesLayer;
    public LayerMask Obstacles;
    public float MaxInteractionDistance;
    public int UnarmedDamage = 3;
    public Animator HandAnimator;
    private bool isTouching = false;
    private float touchTime = 0f;

    private bool isEating = false;
    private bool isMining = false;
    private bool isHoldingLMB = false;
    private bool isHoldingRMB = false;
    private float holdLMBTime = 0f;
    private float holdRMBTime = 0f;

    private ItemHandler miningBLock;
    private float MiningBlockStrength;
    private float MiningDamage;

    private float EatCooldown = 2;
    private Vector2 fromScreenCenter => new Vector2(Screen.width / 2, Screen.height / 2);

    private Inventory PlayerInventory;

    private Dictionary<ToolType, int> WeaponsToID = new() { { ToolType.Axe, 0 }, { ToolType.Pickaxe, 1 },
        { ToolType.Shovel, 2 }, { ToolType.Hoe, 3 }, { ToolType.Sword, 4 } };
    private Dictionary<ToolMaterial, float> MatreialToDamage = new() { { ToolMaterial.Wood, 1 }, { ToolMaterial.Stone, 1.5f },
        { ToolMaterial.Iron, 2 }, {ToolMaterial.Dimond, 3 }};

    private void Start()
    {
        _itemsManager = ItemsDataHandler.Instance.Data;
        PlayerInventory = Inventory.Instance;
    }
    private void Update()
    {
        CheckTouches();
        GetMouseInput();

        if (isMining)
        {
            Mine();
        }
        if (isEating)
        {
            Eat();
        }
    }

    private void CheckTouches()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {

            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    isTouching = true;
                    if (GetSelectedItem().ItemType == ItemType.Food)
                    {
                        if (Eat())
                        {
                            isEating = true;
                            break;
                        }
                    }
                    isEating = false;
                    if (GetBlockInfront() != null)
                    {
                        isMining = true;
                    }
                    break;

                case TouchPhase.Moved:

                    if (t.deltaPosition.magnitude >= 5f && touchTime < 0.15f)
                    {
                        isMining = false;
                        HandAnimator.SetBool("IsMining", false);
                    }
                    break;


                case TouchPhase.Ended:
                    isTouching = false;
                    isMining = false;
                    isEating = false;
                    HandAnimator.SetBool("IsMining", false);
                    try
                    {
                        miningBLock.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop();
                        miningBLock = null;
                    }
                    catch { }
                    ItemHandler blockInFront = GetBlockInfront();
                    if (blockInFront != null)
                    {
                        if (touchTime <= 0.15f)
                        {
                            try
                            {
                                blockInFront.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop();
                            }
                            catch { }
                            IInteractable interactable = blockInFront.GetComponent<IInteractable>();
                            if (interactable != null)
                            {
                                interactable.OnInteract();
                                break;
                            }
                            Hit();
                            Spawn();
                        }
                    }
                    break;
            }
        }

        if (isTouching)
        {
            touchTime += Time.deltaTime;
        }
        else touchTime = 0;
    }

    private void GetMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isHoldingLMB = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (holdLMBTime < 0.2f)
            {
                OnLMBClick();
            }

            holdLMBTime = 0;
            isHoldingLMB = false;
            try
            {
                miningBLock.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop();
            }
            catch { }

            miningBLock = null;
            HandAnimator.SetBool("IsMining", false);
        }
        if (isHoldingLMB)
        {
            holdLMBTime += Time.deltaTime;
        }
        if (holdLMBTime > 0.2f)
        {
            Mine();
        }

        if (Input.GetMouseButtonDown(1))
        {
            isHoldingRMB = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (holdRMBTime < 0.2f)
            {
                OnRMBClick();
            }
            holdRMBTime = 0;
            isHoldingRMB = false;
        }
        if (isHoldingRMB)
        {
            holdRMBTime += Time.deltaTime;
        }
        if (holdRMBTime > 0.2f)
        {
            Item selectedItem = GetSelectedItem();
            if (selectedItem.ItemType != ItemType.Food) return;
            Eat();
        }
    }

    private void OnLMBClick()
    {
        Hit();
    }

    private void OnRMBClick()
    {
        ItemHandler blockInFront = GetBlockInfront();
        if (blockInFront != null)
        {
            if (blockInFront.GetComponent<IInteractable>() != null)
            {
                blockInFront.GetComponent<IInteractable>().OnInteract();
            }
            else Spawn();
        }
    }

    private void Hit()
    {
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance,EnemiesLayer))
        {
            if (hit.collider != null)
            {
                try
                {
                    Item selectedItem = GetSelectedItem();
                    Health targetHealth = hit.collider.GetComponent<Health>();
                    int damage;
                    if (selectedItem.ItemType == ItemType.Tool)
                    {
                        damage = selectedItem.Damage;
                    }
                    else damage = UnarmedDamage;
                    targetHealth.ChangeHealthValue(-damage);
                }
                catch { Debug.Log("cant hit it"); }
            }
        }
    }
    private bool Eat()
    {
        if (StarvingSystem.Instance.CurrentSatietyPoints == StarvingSystem.Instance.MaxSatietyPoints) return false;

        if (EatCooldown > 0)
        {
            EatCooldown -= Time.deltaTime;
            Debug.Log("eating");
        }
        else
        {
            StarvingSystem.Instance.ChangeSatiety(GetSelectedItem().Satiety, GetSelectedItem().SaturationTime);
            PlayerInventory.SelectedSlot.GetHandlingItem().OnCountChange(-1);
            isEating = false;
            EatCooldown = 2f;
        }
        return true;

    }

    private void Mine()
    {

        ItemHandler blockInfront = GetBlockInfront();

        if (blockInfront == null)
        {
            HandAnimator.SetBool("IsMining", false);
            return;
        }

        HandAnimator.SetBool("IsMining", true);
        if (blockInfront != miningBLock || blockInfront == null)
        {
            try { miningBLock.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop(); } catch { }

            miningBLock = blockInfront;

            try { miningBLock.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStart(); } catch { }

            Item miningBlockData = ItemsDataHandler.Instance.Data.items[miningBLock.itemID];

            Item selectedItem = GetSelectedItem();
            MiningBlockStrength = miningBlockData.Strength;

            if (selectedItem.ItemType == ItemType.Tool)
            {
                MiningDamage = miningBlockData.DamageScale[WeaponsToID[selectedItem.ToolType]] * MatreialToDamage[selectedItem.ToolMaterial];
            }
            else MiningDamage = 1;

        }
        else
        {
            MiningBlockStrength -= (MiningDamage * Time.deltaTime);
            if (MiningBlockStrength <= 0)
            {
                Remove(miningBLock.gameObject);
            }
        }
    }

    private void Remove(GameObject objectToRemove)
    {
        Item Object = _itemsManager.items[objectToRemove.GetComponent<ItemHandler>().itemID];
        if (Object.ItemType == ItemType.Block)
        {
            Item selectedItem = GetSelectedItem();
            if ((Object.MinesBy.Contains(selectedItem.name) && Object.MinesBy.Count != 0) || Object.MinesBy.Count == 0)
            {
                ItemHandler item = objectToRemove.GetComponent<ItemHandler>();

                if (item.DroppedItemPrefab != null)
                {
                    Vector3 spawnPos = objectToRemove.transform.position;
                    Destroy(objectToRemove);
                    ItemHandler drop = Instantiate(item.DroppedItemPrefab, spawnPos, Quaternion.identity);
                    drop.OnDrop();
                }
                else
                {
                    item.OnDrop();
                }
            }
            else
            {
                Destroy(objectToRemove);
            }
            NavMeshSurfaceController.Instance.GenerateNavmesh();
        }
    }

    private void Spawn()
    {
        Item selectedItem = GetSelectedItem();

        if (selectedItem.ItemPrefab == null || selectedItem.ItemType != ItemType.Block) return;

        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, MaxInteractionDistance, Obstacles)) return;


        if (Mathf.Abs(transform.position.x - hit.point.x) >= .7f ||
            Mathf.Abs(transform.position.y - hit.point.y) >= 1.06f ||
            Mathf.Abs(transform.position.z - hit.point.z) >= .7f)
        {

            GameObject newCube;
            Vector3 pos = new();
            if (hit.collider.transform.position.x - hit.point.x >= 0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x - 1, hit.collider.transform.position.y, hit.collider.transform.position.z);
            }
            else if (hit.collider.transform.position.x - hit.point.x <= -0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x + 1, hit.collider.transform.position.y, hit.collider.transform.position.z);

            }
            else if (hit.collider.transform.position.z - hit.point.z <= -0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z + 1);

            }
            else if (hit.collider.transform.position.z - hit.point.z >= 0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z - 1);

            }
            else if (hit.collider.transform.position.y - hit.point.y <= -0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1, hit.collider.transform.position.z);

            }
            else if (hit.collider.transform.position.y - hit.point.y >= 0.5f)
            {
                pos = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y - 1, hit.collider.transform.position.z);
            }
            try
            {

                newCube = Instantiate(selectedItem.ItemPrefab.gameObject, pos, Quaternion.identity);
                PlayerInventory.SelectedSlot.GetHandlingItem().OnCountChange(-1);
                NavMeshSurfaceController.Instance.GenerateNavmesh();
            }
            catch { }
        }

    }

    private ItemHandler GetBlockInfront()
    {
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance, Obstacles))
        {
            return hit.collider.GetComponent<ItemHandler>();
        }
        return null;
    }

    private Item GetSelectedItem()
    {
        Item item = new Item();
        try
        {
            item = _itemsManager.items[PlayerInventory.SelectedSlot.GetHandlingItem().GetItemData().ID];
        }
        catch
        {
        }
        return item;
    }
}