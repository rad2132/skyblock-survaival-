using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Farming Manager")]
public class FarmingManager : ScriptableObject
{
    public List<Plant> Plants = new List<Plant>();
    public Plant GetReferncePlant(int ID)
    {
        foreach (Plant plant in Plants)
        {
            if (plant.ID == ID) return plant;
        }
        return null;
    }
}

[Serializable]
public class Plant
{
    public string Name;
    public int ID;
    public List<ItemHandler> PlantableBlocks = new List<ItemHandler>();
    public List<GrowingPhase> Phases = new List<GrowingPhase>();
}

[Serializable]
public class GrowingPhase
{
    public Transform PhaseMesh;
    public float Duration;
    public List<ItemHandler> Drop = new List<ItemHandler>();
}
