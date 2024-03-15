using UnityEngine;

public enum ContainingLiquid
{
    Empty,
    Water,
    Lava
}
public class Bucket : MonoBehaviour
{
    public ContainingLiquid ContainingLiquid;
    public LiquidSource handlingLiquid;
    public int EmptyBucketID;
}   
