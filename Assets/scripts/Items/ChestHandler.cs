using System.Collections;
using System.Threading;
using UnityEngine;

public class ChestHandler : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator _animator;
    public void OnInteract()
    {
       StartCoroutine(OpenChest());
    }
    private IEnumerator OpenChest()
    {
        _animator.SetBool("Open", true);
        PlayerDataHandler.Instance.PlayerInventoryUI.SwitchUIVisibility(false, false, true,false);
        yield return new WaitForEndOfFrame();
        _animator.SetBool("Open", false);
    }
}
