using UnityEngine;

public class PlayerDataHandler : MonoBehaviour
{
    public static PlayerDataHandler Instance;
    public Inventory PlayerInventory;
    public UI_Inventory PlayerInventoryUI;
    
    private void Awake()
    {
        Instance = this;
    }
}
