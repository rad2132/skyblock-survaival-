using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Manager")]
public class ItemsDataManager : ScriptableObject
{
    public List<Item> items = new List<Item>();
}
[System.Serializable]
public class Item
{
    public string name;

    public int StackSize = 64;

    public int ID;

    public ItemType ItemType;

    public ItemHandler ItemPrefab;

    public Sprite Icon;

    [Header("for blocks only")]
    public float Strength;
    public List<string> MinesBy;//оружия из которых может выпасть этот блок
    public List<float> DamageScale = new(5) { 1, 1, 1, 1, 1 };//[0]-axe, [1]-pickaxe, [2]-shovel, [3]-hoe, [4]-sword, [5]-hand

    [Header("for tools only")]
    public ToolMaterial ToolMaterial;
    public ToolType ToolType;
    public int Damage = 3;
    public int Health = 50;

    [Header("for food only")]
    public int Satiety;
    public float SaturationTime;

}
public enum ToolMaterial
{
    Wood, 
    Stone,
    Iron,
    Dimond
}
public enum ToolType
{
    Axe,
    Sword,
    Hoe,
    Pickaxe,
    Shovel
}
public enum ItemType
{
    Block,
    Tool,
    Food,
    Component,
    Plant
}
