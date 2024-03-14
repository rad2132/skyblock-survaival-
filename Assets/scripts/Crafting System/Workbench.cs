using System.Collections;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    [SerializeField] private Workbench2x2 _workbench2x2;
    [SerializeField] private Workbench3x3 _workbench3x3;
    public static Workbench Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void TryCraft()
    {
        StartCoroutine(OnCraftTry());
    }

    private IEnumerator OnCraftTry()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("try craft");
        if (_workbench2x2.WorkbenchUI.activeSelf)
        {
            Debug.Log("2x2 is active");
            Item resultRefence = new Item();
            int resultCount = 0;
            if (RecipesDataHandler.Instance.RecipesManager.OnCraftTry(_workbench2x2.UpperLeft.GetHandlingItem().GetItemData().ID,
                _workbench2x2.UpperRight.GetHandlingItem().GetItemData().ID, -1, _workbench2x2.LowerLeft.GetHandlingItem().GetItemData().ID,
                _workbench2x2.LowerRight.GetHandlingItem().GetItemData().ID, -1, -1, -1, -1, ref resultCount, ref resultRefence))
            {
                _workbench2x2.ResultSlot.GetHandlingItem().SetItem(resultRefence.ID);
                resultCount--;
                _workbench2x2.ResultSlot.GetHandlingItem().OnCountChange(resultCount);
            }
            else
            {
                _workbench2x2.ResultSlot.GetHandlingItem().ResetItem();
                Debug.Log("wtf");
            }
        }
        else if (_workbench3x3.WorkbenchUI.activeSelf)
        {
            Debug.Log("3x3 is active");
            Item resultRefence = new Item();
            int resultCount = 0;
            if (RecipesDataHandler.Instance.RecipesManager.OnCraftTry(_workbench3x3.UpperLeft.GetHandlingItem().GetItemData().ID,
                _workbench3x3.UpperCenter.GetHandlingItem().GetItemData().ID, _workbench3x3.UpperRight.GetHandlingItem().GetItemData().ID,
                _workbench3x3.MiddleLeft.GetHandlingItem().GetItemData().ID, _workbench3x3.MiddleCenter.GetHandlingItem().GetItemData().ID
                , _workbench3x3.MiddleRight.GetHandlingItem().GetItemData().ID, _workbench3x3.LowerLeft.GetHandlingItem().GetItemData().ID
                , _workbench3x3.LowerCenter.GetHandlingItem().GetItemData().ID, _workbench3x3.LowerRight.GetHandlingItem().GetItemData().ID, ref resultCount, ref resultRefence))
            {
                _workbench3x3.ResultSlot.GetHandlingItem().SetItem(resultRefence.ID);
                resultCount--;
                _workbench3x3.ResultSlot.GetHandlingItem().OnCountChange(resultCount);
            }
            else
            {
                Debug.Log("wtf");
                _workbench3x3.ResultSlot.GetHandlingItem().ResetItem();
            }
        }
    }
    public void OnItemCreated()
    {
        if (_workbench2x2.gameObject.activeSelf)
        {
            _workbench2x2.UpperLeft.GetHandlingItem().OnCountChange(-1);
            _workbench2x2.UpperRight.GetHandlingItem().OnCountChange(-1);
            _workbench2x2.LowerLeft.GetHandlingItem().OnCountChange(-1);
            _workbench2x2.LowerRight.GetHandlingItem().OnCountChange(-1);
        }
        else if (_workbench3x3.gameObject.activeSelf)
        {
            _workbench3x3.UpperLeft.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.UpperCenter.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.UpperRight.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.MiddleLeft.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.MiddleCenter.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.MiddleRight.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.LowerLeft.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.LowerCenter.GetHandlingItem().OnCountChange(-1);
            _workbench3x3.LowerRight.GetHandlingItem().OnCountChange(-1);
        }
    }
}
