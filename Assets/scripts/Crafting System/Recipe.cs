using UnityEngine;

[CreateAssetMenu(fileName = "Recipe")]
public class Recipe : ScriptableObject
{
    [field: SerializeField] public ItemHandler UpperLeft { get; private set; }
    [field: SerializeField] public ItemHandler UpperCenter { get; private set; }
    [field: SerializeField] public ItemHandler UpperRight { get; private set; }
    [field: Space]
    [field: SerializeField] public ItemHandler MiddleLeft { get; private set; }
    [field: SerializeField] public ItemHandler MiddleCenter { get; private set; }
    [field: SerializeField] public ItemHandler MiddleRight { get; private set; }
    [field: Space]
    [field: SerializeField] public ItemHandler LowerLeft { get; private set; }
    [field: SerializeField] public ItemHandler LowerCenter { get; private set; }
    [field: SerializeField] public ItemHandler LowerRight { get; private set; }
    [field: Space]
    [field: SerializeField] public ItemHandler Result { get; private set; }

    [field: SerializeField] public int ResultCount { get; private set; } = 1;
    [field: SerializeField] public bool SingleItemRequiered { get; private set; }
    
    public int UpperLeftItemId()
    {
        if (UpperLeft != null)
        {
            return UpperLeft.itemID;
        }
        return -1;
    }
    public int UpperCenterItemId()
    {
        if (UpperCenter != null)
        {
            return UpperCenter.itemID;
        }
        return -1;
    }

    public int UpperRightItemId()
    {
        if (UpperRight != null)
        {
            return UpperRight.itemID;
        }
        return -1;
    }

    public int MiddleLeftItemId()
    {
        if (MiddleLeft != null)
        {
            return MiddleLeft.itemID;
        }
        return -1;
    }
    public int MiddleCenterItemId()
    {
        if (MiddleCenter != null)
        {
            return MiddleCenter.itemID;
        }
        return -1;
    }

    public int MiddleRightItemId()
    {
        if (MiddleRight != null)
        {
            return MiddleRight.itemID;
        }
        return -1;
    }

    public int LowerLeftItemId()
    {
        if (LowerLeft != null)
        {
            return LowerLeft.itemID;
        }
        return -1;
    }
    public int LowerCenterItemId()
    {
        if (LowerCenter != null)
        {
            return LowerCenter.itemID;
        }
        return -1;
    }

    public int LowerRightItemId()
    {
        if (LowerRight != null)
        {
            return LowerRight.itemID;
        }
        return -1;
    }
}