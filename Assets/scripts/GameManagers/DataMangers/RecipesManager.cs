using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipesManager")]
public class RecipesManager : ScriptableObject
{
    [SerializeField] private ItemsDataManager itemsManager;
    [SerializeField] private List<Recipe> Recipes = new List<Recipe>();
    public bool OnCraftTry(int upperLeftID, int upperCenterID, int upperRightID,
        int middleLeftID, int middleCenterID, int middleRightID,
        int lowerLeftID, int lowerCenterID, int lowerRightID, ref int resultCount, ref Item resultReference)
    {
        
        foreach (Recipe recipe in Recipes)
        {
            resultCount = recipe.ResultCount;
            resultReference = itemsManager.items[recipe.Result.itemID];
            if (recipe.SingleItemRequiered)
            {
                if (upperLeftID == recipe.UpperLeft())
                {
                    return true;
                }

                if (upperCenterID == recipe.UpperCenter())
                {
                   return true;
                }

                if (upperRightID == recipe.UpperRight())
                {
                   return true;
                }
    
                if (middleLeftID == recipe.MiddleLeft())
                {
                    return true;
                }
                if (middleCenterID == recipe.MiddleCenter())
                {
                   return true;
                }
               
                if (middleLeftID == recipe.MiddleLeft())
                {
                    return true;
                }
               
                if (lowerLeftID == recipe.LowerLeft())
                {
                    return true;
                }

                if (lowerCenterID == recipe.LowerCenter())
                {
                    return true;
                }

                if (lowerRightID == recipe.LowerRight())
                {
                   
                    return true;
                }
                return false;
            }
            else

            if(upperLeftID == recipe.UpperLeft())
            {

                if(upperCenterID == recipe.UpperCenter())
                {

                    if(upperRightID == recipe.UpperRight())
                    {

                        if(middleLeftID == recipe.MiddleLeft())
                        {

                            if(middleCenterID == recipe.MiddleCenter())
                            {

                                if(middleLeftID == recipe.MiddleLeft())
                                {

                                    if(lowerLeftID == recipe.LowerLeft())
                                    {

                                        if(lowerCenterID == recipe.LowerCenter())
                                        {
                                            if(lowerRightID == recipe.LowerRight())
                                            {
                                                resultReference = itemsManager.items[recipe.Result.itemID];
                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
}

[System.Serializable]
public class Recipe
{
    public ItemHandler _upperLeft;
    public ItemHandler _upperCenter;
    public ItemHandler _uperRight;

    public ItemHandler _middleLeft;
    public ItemHandler _middleCenter;
    public ItemHandler _middleRight;

    public ItemHandler _lowerLeft;
    public ItemHandler _lowerCenter;
    public ItemHandler _lowerRight;

    public ItemHandler Result;
    public int ResultCount;
    public bool SingleItemRequiered;
    public int UpperLeft()
    {
        if (_upperLeft != null)
        {
            return _upperLeft.itemID;
        }
        return -1;
    }
    public int UpperCenter()
    {
        if (_upperCenter != null)
        {
            return _upperCenter.itemID;
        }
        return -1;
    }

    public int UpperRight()
    {
        if (_uperRight != null)
        {
            return _uperRight.itemID;
        }
        return -1;
    }

    public int MiddleLeft()
    {
        if (_middleLeft != null)
        {
            return _middleLeft.itemID;
        }
        return -1;
    }
    public int MiddleCenter()
    {
        if (_middleCenter != null)
        {
            return _middleCenter.itemID;
        }
        return -1;
    }

    public int MiddleRight()
    {
        if (_middleRight != null)
        {
            return _middleRight.itemID;
        }
        return -1;
    }

    public int LowerLeft()
    {
        if (_lowerLeft != null)
        {
            return _lowerLeft.itemID;
        }
        return -1;
    }
    public int LowerCenter()
    {
        if (_lowerCenter != null)
        {
            return _lowerCenter.itemID;
        }
        return -1;
    }

    public int LowerRight()
    {
        if (_lowerRight != null)
        {
            return _lowerRight.itemID;
        }
        return -1;
    }
}
