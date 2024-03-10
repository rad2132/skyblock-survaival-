using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItemsPanel : MonoBehaviour
{
    public static DragItemsPanel Instance;

    private void Awake()
    {
        Instance = this;
    }
}
