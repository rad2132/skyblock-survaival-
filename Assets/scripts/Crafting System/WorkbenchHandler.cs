using InventorySystem;
using UnityEngine;

public class  WorkbenchHandler : MonoBehaviour,IInteractable
{
    public void OnInteract()
    {
        EventAggregator.QuickAccessInventoryPanelRendering.Publish();
        
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false,true,false,false);
    }
}
