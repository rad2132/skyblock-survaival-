using UnityEngine;

public class ItemsDataHandler : MonoBehaviour
{
    public static ItemsDataHandler Instance;
    public ItemsDataManager Data;
    private void Awake()
    {
        Instance = this;
    }
}
