using UnityEngine;

public class  WorkbenchHandler : MonoBehaviour,IInteractable
{
    public void OnInteract()
    {
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false,true,false,false);
    }
}
