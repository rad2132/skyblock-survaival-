using UnityEngine;

public class Workbench : MonoBehaviour
{
    public static Workbench Instance;

    [SerializeField] private Workbench2x2 _workbench2x2;
    [SerializeField] private Workbench3x3 _workbench3x3;
  
    private void Awake()
    {
        Instance = this;
    }

    public void OnCraftTry()
    {
        if (_workbench2x2.WorkbenchUI.activeSelf)
        {
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
        }
        else if(_workbench3x3.WorkbenchUI.activeSelf)
        {
            Item resultRefence = new Item();
            int resultCount = 0;
            if (RecipesDataHandler.Instance.RecipesManager.OnCraftTry(_workbench3x3.UpperLeft.GetHandlingItem().GetItemData().ID,
                _workbench3x3.UpperCenter.GetHandlingItem().GetItemData().ID, _workbench3x3.UpperRight.GetHandlingItem().GetItemData().ID,
                _workbench3x3.MiddleLeft.GetHandlingItem().GetItemData().ID, _workbench3x3.MiddleCenter.GetHandlingItem().GetItemData().ID
                , _workbench3x3.MiddleRight.GetHandlingItem().GetItemData().ID, _workbench3x3.LowerLeft.GetHandlingItem().GetItemData().ID
                , _workbench3x3.LowerCenter.GetHandlingItem().GetItemData().ID, _workbench3x3.LowerRight.GetHandlingItem().GetItemData().ID,ref resultCount,ref resultRefence))
            {
                _workbench3x3.ResultSlot.GetHandlingItem().SetItem(resultRefence.ID);
                resultCount--;
                _workbench3x3.ResultSlot.GetHandlingItem().OnCountChange(resultCount);
            }
        }
    }
}
