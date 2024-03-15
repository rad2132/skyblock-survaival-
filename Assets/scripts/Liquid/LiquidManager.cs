using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LiquidManager : MonoBehaviour
{
    public static LiquidManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void AbortStream(List<Liquid> abortedBlocks, float dryTime)
    {
            StartCoroutine(OnStreamAbort(abortedBlocks, dryTime));
    }
    private IEnumerator OnStreamAbort(List<Liquid> abortedBlocks, float dryTime)
    {
        foreach (Liquid block in abortedBlocks)
        {
            yield return new WaitForSeconds(dryTime);
            Destroy(block.gameObject);
        }
    }
}
