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
                if (upperLeftID == recipe.UpperLeftItemId() && upperLeftID != -1 )
                {
                    return true;
                }

                if (upperCenterID == recipe.UpperCenterItemId() && upperCenterID != -1)
                {
                   return true;
                }

                if (upperRightID == recipe.UpperRightItemId() && upperRightID != -1)
                {
                   return true;
                }
    
                if (middleLeftID == recipe.MiddleLeftItemId() && middleLeftID != -1 )
                {
                    return true;
                }
                if (middleCenterID == recipe.MiddleCenterItemId() && middleCenterID != -1)
                {
                   return true;
                }
               
                if (middleRightID == recipe.MiddleRightItemId() && middleRightID != -1)
                {
                    return true;
                }
               
                if (lowerLeftID == recipe.LowerLeftItemId() && lowerLeftID != -1 )
                {
                    return true;
                }

                if (lowerCenterID == recipe.LowerCenterItemId() && lowerCenterID != -1)
                {
                    return true;
                }

                if (lowerRightID == recipe.LowerRightItemId() && lowerRightID != -1)
                {
                   
                    return true;
                }
                return false;
            }
            else

            if(upperLeftID == recipe.UpperLeftItemId())
            {

                if(upperCenterID == recipe.UpperCenterItemId())
                {

                    if(upperRightID == recipe.UpperRightItemId())
                    {

                        if(middleLeftID == recipe.MiddleLeftItemId())
                        {

                            if(middleCenterID == recipe.MiddleCenterItemId())
                            {

                                if(middleRightID == recipe.MiddleRightItemId())
                                {

                                    if(lowerLeftID == recipe.LowerLeftItemId())
                                    {

                                        if(lowerCenterID == recipe.LowerCenterItemId())
                                        {
                                            if(lowerRightID == recipe.LowerRightItemId())
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