using UnityEngine;

public class FarmDataHandler : MonoBehaviour
{
    public static FarmDataHandler Instance;
    public FarmingManager FarmingManager;
    private void Awake()
    {
        Instance = this;
    }
}
