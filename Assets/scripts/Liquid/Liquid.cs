using System.Collections.Generic;
using UnityEngine;

public enum LiquidType
{
    Water,
    Lava
}
public class Liquid : MonoBehaviour
{
    public LayerMask Obstacles;
    public LiquidSource Source;
    public LiquidType LiquidType = LiquidType.Water;
    public ItemHandler CollisionResult;
    [HideInInspector]
    public bool AboutToDry = false;
    public int BucketOFLiquidID;
    public int NumberInStream = 0;

    public virtual void ContinueStream()
    {
        try
        {
            if (NumberInStream == Source.StreamLength || NumberInStream >= Source.StreamLength || transform.position.y <= -10) return;

            if (OnStreamContinue(Vector3.down)) return;
            if (OnStreamContinue(Vector3.forward)) return;
            if (OnStreamContinue(Vector3.back)) return;
            if (OnStreamContinue(Vector3.right)) return;
            if (OnStreamContinue(Vector3.left)) return;
        }
        catch { }
        
    }
    private bool OnStreamContinue(Vector3 streamDirection)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, streamDirection);

        Liquid liquid;
        if (Physics.Raycast(ray, out hit, .5f, Obstacles))
        {
            liquid = hit.collider.GetComponent<Liquid>();
            if (liquid != null && liquid.LiquidType != this.LiquidType)
            {
                liquid.OnLiquidDestroy();
                Instantiate(CollisionResult, transform.position + Vector3.back, Quaternion.identity);
                return false;
            }
            else if (liquid != null && !liquid.AboutToDry)
            {
                return false;
            }
            else if (hit.collider.GetComponent<ItemHandler>() != null) return false;
        }

        Liquid newLiqudBlock;
        if (streamDirection == Vector3.down)
        {
            newLiqudBlock = Instantiate(Source.StreamPhases[0], transform.position + streamDirection, Quaternion.identity);
        }
        else
        {
            int newBlockNumber = 0;
            Vector3 newBlockPostion = transform.position + streamDirection;
            if (Physics.Raycast(newBlockPostion, Vector3.down, .5f, Obstacles))
            {
                newBlockNumber = NumberInStream + 1;
            }
            newLiqudBlock = Instantiate(Source.StreamPhases[newBlockNumber], transform.position + streamDirection, Quaternion.identity);
            newLiqudBlock.NumberInStream = newBlockNumber;
        }
        newLiqudBlock.Source = Source;
        Source.handlingBlocks.Add(newLiqudBlock);
        return true;

    }

    public virtual void OnStreamChange()
    {
        OnLiquidDestroy();
    }
    public virtual void OnLiquidDestroy()
    {
        List<Liquid> blocksToDestroy = new List<Liquid>();
        bool addBlocksToList = false;

        foreach (Liquid block in Source.handlingBlocks)
        {
            if (block == this)
            {
                addBlocksToList = true;
            }

            if (addBlocksToList)
            {
                block.AboutToDry = true;
                blocksToDestroy.Add(block);
            }
        }
        foreach (Liquid block in blocksToDestroy)
        {
            Source.handlingBlocks.Remove(block);
        }
        LiquidManager.Instance.AbortStream(blocksToDestroy, Source.DryTime);
    }
}
