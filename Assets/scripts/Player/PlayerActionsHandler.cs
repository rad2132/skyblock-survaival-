using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class PlayerActionsHandler : MonoBehaviour
{
    private ItemsDataManager _itemsManager;
    public LayerMask EnemiesLayer;
    public LayerMask Obstacles;
    public LayerMask Liquids;
    public LayerMask Plants;
    public List<ItemHandler> FarmableBlocks = new();
    public ItemHandler FarmLandPrefab;
    public float MaxInteractionDistance;
    public int UnarmedDamage = 3;
    public Animator HandAnimator;
    private bool isTouching = false;
    private float touchTime = 0f;

    private bool isEating;
    private bool isMining;
    private bool isHoldingLMB;
    private bool isHoldingRMB;
    private float holdLMBTime;
    private float holdRMBTime;

    private ItemHandler miningBLock;
    private float MiningBlockStrength;
    private float MiningDamage;

    private float EatCooldown = 2;
    private Vector2 fromScreenCenter => new(Screen.width / 2, Screen.height / 2);

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
        //CheckTouches();
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

                    if (t.deltaPosition.magnitude >= 4f && touchTime < 0.15f)
                    {
                        Debug.Log("cannot move");
                        isMining = false;
                        HandAnimator.SetBool("IsMining", false);
                    }
                    break;

                case TouchPhase.Ended:
                    isTouching = false;
                    isMining = false;
                    isEating = false;
                    HandAnimator.SetBool("IsMining", false);
                    HandAnimator.SetBool("IsEating", false);
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
                            Spawn(GetSelectedItem().ItemPrefab.gameObject);
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
            CollectPlant();
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

    private void OnRMBClick()
    {
        ItemHandler blockInFront = GetBlockInfront();
        Item selectedItem = GetSelectedItem();
        if (blockInFront == null) return;
        
        if (!Player.Instance.InputActions.Player.Bend.IsPressed() && blockInFront.TryGetComponent(out IInteractable interactable))
        {
            interactable.OnInteract();
            return;
        }

        if (selectedItem.ID != -1 && selectedItem.ItemType == ItemType.Block)
        {
            try
            {
                Spawn(selectedItem.ItemPrefab.gameObject);
            }
            catch { }
            return;
        }

        if (selectedItem.ItemType == ItemType.Plant)
        {
            PlantHandler plantHandler = selectedItem.ItemPrefab.GetComponent<PlantHandler>();
            if (plantHandler != null && plantHandler.IsPlantable(blockInFront))
            {

                Ray ray = new Ray(blockInFront.transform.position, Vector3.up);
                if (!Physics.Raycast(ray, 0.5f, Obstacles))
                {

                    PlantHandler newPlant = Instantiate(plantHandler, blockInFront.transform.position + Vector3.up, Quaternion.identity);
                    newPlant.Plant();
                    PlayerInventory.SelectedSlot.GetHandlingItem().OnCountChange(-1);
                }
            }
            return;
        }
        
        if(GetSelectedItem().ToolType == ToolType.Hoe)
        {
            CreateFarmland();
            return;
        }
        try
        {
            CollectLiquid(GetSelectedItem().ItemPrefab.GetComponent<Bucket>());
        }
        catch { }

    }

    private void CollectPlant()
    {
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance, Plants))
        {
            Debug.Log(hit.collider.name);
            PlantHandler plant = hit.collider.GetComponent<PlantHandler>();
            if (plant != null)
            {
                plant.DestroyPlant();
            }
        }
    }

    private void CollectLiquid(Bucket bucket)
    {
        if (bucket == null) return;

        if (bucket.ContainingLiquid == ContainingLiquid.Empty)
        {
            LiquidSource sourceInFront = GetLiquidSourceInFront();
            if (sourceInFront != null)
            {
                PlayerInventory.SelectedSlot.GetHandlingItem().SetItem(sourceInFront.BucketOFLiquidID);
                sourceInFront.OnLiquidDestroy();
            }
        }
        else if (GetBlockInfront() != null)
        {
            Spawn(bucket.handlingLiquid.gameObject);
            PlayerInventory.SelectedSlot.GetHandlingItem().SetItem(bucket.EmptyBucketID);
        }
    }

    private void Hit()
    {
        HandAnimator.SetTrigger("Hit");
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance, EnemiesLayer))
        {
            if (hit.collider != null)
            {
                try
                {
                    Item selectedItem = GetSelectedItem();
                    Health targetHealth = hit.collider.GetComponent<Health>();
                    targetHealth.ChangeHealthValue(-(selectedItem.ItemType == ItemType.Tool ? selectedItem.Damage : UnarmedDamage));
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
            HandAnimator.SetBool("IsEating", true);
        }
        else
        {
            StarvingSystem.Instance.ChangeSatiety(GetSelectedItem().Satiety, GetSelectedItem().SaturationTime);
            PlayerInventory.SelectedSlot.GetHandlingItem().OnCountChange(-1);
            isEating = false;
            HandAnimator.SetBool("IsEating", false);
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
        Item selectedItem = GetSelectedItem();
        
        if (blockInfront != miningBLock)
        {
            try { miningBLock.GetComponentInChildren<BlockBreakingVisualiser>().OnBreakingStop(); } catch { }

            miningBLock = blockInfront;

            Item miningBlockData = ItemsDataHandler.Instance.Data.items[miningBLock.itemID];

            MiningBlockStrength = miningBlockData.Strength;

            MiningDamage = selectedItem.ItemType == ItemType.Tool
                ? miningBlockData.DamageScale[WeaponsToID[selectedItem.ToolType]] * MatreialToDamage[selectedItem.ToolMaterial] : 1;
            try
            {
                BlockBreakingVisualiser breakingVisualiser = miningBLock.GetComponentInChildren<BlockBreakingVisualiser>();
                breakingVisualiser.AnimationSpeed = MiningDamage / (miningBlockData.Strength / 5);
                breakingVisualiser.OnBreakingStart();
            }
            catch { }
        }
        else
        {
            MiningBlockStrength -= MiningDamage * Time.deltaTime;
            if (MiningBlockStrength <= 0)
            {
                try
                {
                    Remove(miningBLock.gameObject);
                }
                catch { }

                PlayerInventory.SelectedSlot.GetHandlingItem().Damage();
            }
        }
    }

    private void CreateFarmland()
    {
        ItemHandler blockInFront = GetBlockInfront();
        if (FarmableBlocks.All(block => block.itemID != blockInFront.itemID)) return;

        Instantiate(FarmLandPrefab, blockInFront.transform.position, Quaternion.identity);
        Destroy(blockInFront.gameObject);
    }

    private void Remove(GameObject objectToRemove)
    {
        Item Object = _itemsManager.items[objectToRemove.GetComponent<ItemHandler>().itemID];
        Vector3 blockPos = objectToRemove.transform.position;
        RaycastHit hit;

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

            if (Physics.Raycast(blockPos, Vector3.up, out hit, .5f, Liquids))
            {
                Liquid liquidBlock = hit.collider.GetComponent<Liquid>();
                if (liquidBlock != null)
                {
                    liquidBlock.OnStreamChange();
                }
            }
            if (Physics.Raycast(blockPos, Vector3.up, out hit, .5f, Plants))
            {
                PlantHandler plant = hit.collider.GetComponent<PlantHandler>();
                if (plant != null)
                {
                    plant.DestroyPlant();
                }
            }
        }
    }

    private void Spawn(GameObject objectToSpawn)
    {
        if (objectToSpawn == null) return;
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, MaxInteractionDistance, Obstacles)) return;

        if (Mathf.Abs(transform.position.x - hit.point.x) >= .7f ||
            Mathf.Abs(transform.position.y - hit.point.y) >= 1.85f ||
            Mathf.Abs(transform.position.z - hit.point.z) >= .7f || objectToSpawn.GetComponent<LiquidSource>() != null)
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
                if (Physics.Raycast(ray, out hit, MaxInteractionDistance, Liquids))
                {
                    Liquid liquid = hit.collider.GetComponent<Liquid>();
                    if (liquid != null)
                    {
                        liquid.OnLiquidDestroy();
                    }
                }
                newCube = Instantiate(objectToSpawn, pos, Quaternion.identity);
                PlayerInventory.SelectedSlot.GetHandlingItem().OnCountChange(-1);
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

    private LiquidSource GetLiquidSourceInFront()
    {
        Ray ray = Camera.main.ScreenPointToRay(fromScreenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance, Liquids))
        {
            return hit.collider.GetComponent<LiquidSource>();
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
