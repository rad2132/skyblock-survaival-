using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDrop
{
    [field: SerializeField] public ItemHandler Item { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float Probability { get; private set; }
}
