using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Remelting Manager")]
public class RemeltingManager : ScriptableObject
{
    public List<Fuel> FuelVariants = new List<Fuel>();
    public List<RemeltingRecipe> Recipes = new List<RemeltingRecipe>();

    public Fuel GetFuel(ItemHandler item)
    {
        foreach (Fuel fuel in FuelVariants)
        {

            if(item == fuel.Item) return fuel;
        }
        return null;
    }

    public RemeltingRecipe GetRecipe(ItemHandler item)
    {
        foreach(RemeltingRecipe recipe in Recipes)
        {
            if(recipe.RawMaterial == item) return recipe;
        }
        return null;
    }

}
[System.Serializable]
public class RemeltingRecipe 
{
    public ItemHandler RawMaterial;
    public ItemHandler Result;
    public float MeltingTime;
}
[System.Serializable]
public class Fuel
{
    public ItemHandler Item;
    public float BurningTime;
}
