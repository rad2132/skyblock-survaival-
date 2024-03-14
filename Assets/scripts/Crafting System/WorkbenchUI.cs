using UnityEngine;

public class WorkbenchUI : MonoBehaviour
{
    public static WorkbenchUI Instance;
    private void Awake()
    {
        Instance = this;
    }
}
