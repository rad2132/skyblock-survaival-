using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UI_Inventory : MonoBehaviour
{

    [SerializeField] private GameObject _inventoryGameObject;

    [SerializeField] private GameObject _workbench2x2UI;
    [SerializeField] private GameObject _workbench3x3UI;
    [SerializeField] private GameObject _chestUI;
    [SerializeField] private GameObject _furnaceUI;
    [SerializeField] private List<GameObject> QuickAcessButtons = new List<GameObject>();

    public bool IsOpen { get; private set; } = false;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void SwitchUIVisibility(bool openWorkbench2x2,bool openWorkbench3x3, bool openChest,bool openFurnace)
    {
        IsOpen = !IsOpen;
        _workbench2x2UI.SetActive(openWorkbench2x2);
        _workbench3x3UI.SetActive(openWorkbench3x3);
        _chestUI.SetActive(openChest);
        _furnaceUI.SetActive(openFurnace);
        if (!IsOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        foreach (GameObject item in QuickAcessButtons)
        {
            item.SetActive(!IsOpen);
        }
        _inventoryGameObject.SetActive(IsOpen);
    }

    private void SelectSlot(int slotNumber)
    {
        Inventory.Instance.SelectSlot(slotNumber);
    }

    public void OnUISwitch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SwitchUIVisibility(true,false,false,false);
        }
    }

    public void OnUISwitch()
    {
        SwitchUIVisibility(true, false, false,false);
    }

    public void OnSlot1Selected(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SelectSlot(1);
        }

    }

    public void OnSlot2Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SelectSlot(2);
        }

    }
    public void OnSlot3Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SelectSlot(3);
        }
    }
    public void OnSlot4Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(4);
        }
    }
    public void OnSlot5Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(5);
        }
    }
    public void OnSlot6Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(6);
        }
    }
    public void OnSlot7Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(7);
        }
    }
    public void OnSlot8Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(8);
        }
    }
    public void OnSlot9Seletected(InputAction.CallbackContext context)
    {
        if (context.started)
        {

            SelectSlot(9);
        }
    }
    public void OnSlot1Selected()
    {

        SelectSlot(1);


    }

    public void OnSlot2Seletected()
    {

        SelectSlot(2);


    }
    public void OnSlot3Seletected()
    {

        SelectSlot(3);

    }
    public void OnSlot4Seletected()
    {

        SelectSlot(4);

    }
    public void OnSlot5Seletected()
    {

        SelectSlot(5);

    }
    public void OnSlot6Seletected()
    {


        SelectSlot(6);

    }
    public void OnSlot7Seletected()
    {

        SelectSlot(7);

    }
    public void OnSlot8Seletected()
    {

        SelectSlot(8);

    }
    public void OnSlot9Seletected()
    {


        SelectSlot(9);

    }
}
