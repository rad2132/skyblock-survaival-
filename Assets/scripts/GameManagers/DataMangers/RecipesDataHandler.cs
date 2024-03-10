using UnityEngine;

public class RecipesDataHandler : MonoBehaviour
{
    public static RecipesDataHandler Instance;
    public RecipesManager RecipesManager;
    private void Awake()
    {
        Instance = this;
    }
}
