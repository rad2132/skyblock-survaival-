using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]

public class LiquidSource : Liquid
{
    public int StreamLength;
    public float DryTime = 1;
    public List<Liquid> StreamPhases = new List<Liquid>();
    public List<Liquid> handlingBlocks = new List<Liquid>();
    private bool _ableToContinue = true;
  

    private void FixedUpdate()
    {
        if (AboutToDry) return;
        if (handlingBlocks.Count == 0) ContinueStream();
        else if (_ableToContinue) StartCoroutine(OnStreamContinue());
    }
    private IEnumerator OnStreamContinue()
    {
        _ableToContinue = false;
        yield return new WaitForSeconds(1f);      
        if (AboutToDry) yield break;
        handlingBlocks[handlingBlocks.Count - 1].ContinueStream();
        _ableToContinue = true;
    }
    public override void ContinueStream()
    {
        base.ContinueStream();
    }
    public override void OnStreamChange()
    {
        handlingBlocks[0].OnLiquidDestroy();
    }
    public override void OnLiquidDestroy()
    {
        if (handlingBlocks.Count > 0)
        {
            OnStreamChange();
        }
        Destroy(gameObject);
    }

}
