using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public InputActions InputActions { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        InputActions = new();
        InputActions.Enable();
    }
}