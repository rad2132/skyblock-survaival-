using System.Collections.Generic;
using UnityEngine;

public class LogHandler : ItemHandler
{
    [SerializeField]
    private List<LeafBlockHandler> leaves = new List<LeafBlockHandler>();
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnDrop()
    {
        foreach (LeafBlockHandler leaf in leaves)
        {
            if (leaf != null) 
            {
                leaf.OnLogDrop();
            }
        }
        base.OnDrop();
        
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
    }
}
