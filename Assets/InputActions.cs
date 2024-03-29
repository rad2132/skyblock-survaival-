//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bd1a499b-ba11-45e3-92dd-7e95fa29030f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b06493a6-7d41-4c23-ab81-9cd38f1a905e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""018956a3-32b2-4e02-bad0-3539d679aadf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""3a91a88a-3968-402e-ab77-f6b54a7bd427"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d084ce3e-af22-40f7-a119-5e799dc058f8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Looking"",
                    ""type"": ""Value"",
                    ""id"": ""7bef35bd-ae29-4cb9-96b8-5ce4ef58942e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3fe34896-e727-47f5-8e6e-8e05914d4ecf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Touch"",
                    ""type"": ""Value"",
                    ""id"": ""fefa6f38-6cf5-413c-b055-94d086f9602b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Bend"",
                    ""type"": ""Button"",
                    ""id"": ""9e5b3df5-92e5-4bad-a459-b6739acd8503"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bbc982b4-7fcb-4e81-866b-036d9d367e6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""055a30cb-3483-4d16-9643-a59a791ea472"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""744e3583-014e-4ef4-aabe-a4f9647a84c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3c22cc3-48bb-44f1-979a-be1d0ecdf4ca"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""27f23760-932f-42c3-aa4d-d500d8c4272c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""948e63cf-f4ef-49f5-90ad-1b949235d1f9"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Looking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc41a8c5-af2e-4061-a6e1-34c5cef6f77f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85cabdc2-fe13-4d64-a4d0-6c8d7481aad8"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Touch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0c16547-ee9d-48c7-ac77-3f8a65b6f7b7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WSAD"",
                    ""id"": ""4b66278c-8828-44dc-b5ca-8480d8619339"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ac264189-f011-419e-86bc-eecd93114853"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""18970f2f-9c18-4440-b3cf-f71ebf322216"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7195c881-feb3-42c3-9e4e-d55a9c7bb769"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f0cc9197-da49-4d87-8452-a647e4204245"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2ff48476-ee12-4c2d-ba11-7985132367b5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aaf9afd0-ab1d-40b1-8477-091e78d81f75"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cc02811-7b06-4d26-aa08-c2b8996d2af5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73e3e39d-4745-4b73-89cd-6b30f4383cb7"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ed4fa78-064c-4712-b898-d3018eac2f70"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory"",
            ""id"": ""128eded9-e6dd-41c2-a40f-2f0096c77713"",
            ""actions"": [
                {
                    ""name"": ""SelectSlot1"",
                    ""type"": ""Button"",
                    ""id"": ""ccd85a85-31c2-41bf-8fe3-deb14f1bc4b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot2"",
                    ""type"": ""Button"",
                    ""id"": ""67649664-ad02-4255-ab65-e54c620aebdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot3"",
                    ""type"": ""Button"",
                    ""id"": ""525a8560-ed56-4d64-9c87-0e95425d1dfb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot4"",
                    ""type"": ""Button"",
                    ""id"": ""e8444bfa-c5a7-472e-a0b2-0d9a4967ac8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot5"",
                    ""type"": ""Button"",
                    ""id"": ""31825529-b4b9-48e8-9fc2-b57681c47164"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot6"",
                    ""type"": ""Button"",
                    ""id"": ""abf93fdc-2389-491a-a3fd-0c681524b7ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot7"",
                    ""type"": ""Button"",
                    ""id"": ""3c8b85c2-dd94-4bdc-8b12-91b7c2348bc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot8"",
                    ""type"": ""Button"",
                    ""id"": ""7503675c-fbd1-42e7-8e98-5bb9b12326f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SelectSlot9"",
                    ""type"": ""Button"",
                    ""id"": ""48c05754-88f4-4e52-9656-b392184390c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchInventoryVisibility"",
                    ""type"": ""Button"",
                    ""id"": ""af55ecd5-e950-417b-9920-ff87f1ff8ff8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b347faaa-104f-45c7-9444-446e0cbe410b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b26f6014-587a-4c16-8b94-88fdf65ed9b4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff717780-2641-43e3-a98d-cb1441a5aeef"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ee73b07-7597-4e26-9892-f364c7504ad4"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19211c4e-c3f9-466b-a198-30ba93ceb9f5"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d8c47ba-e483-48a1-a575-63a8fc62f5d2"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6189829a-dac4-4d80-b769-b3086ab966e1"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""788a8778-c5f0-4563-b872-e4bf27dd80cb"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be6d56b7-2839-4bc7-8650-29a8ea798e8d"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectSlot9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96a8cd20-d031-4475-a806-12ac1f17be11"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchInventoryVisibility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Looking = m_Player.FindAction("Looking", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Touch = m_Player.FindAction("Touch", throwIfNotFound: true);
        m_Player_Bend = m_Player.FindAction("Bend", throwIfNotFound: true);
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_SelectSlot1 = m_Inventory.FindAction("SelectSlot1", throwIfNotFound: true);
        m_Inventory_SelectSlot2 = m_Inventory.FindAction("SelectSlot2", throwIfNotFound: true);
        m_Inventory_SelectSlot3 = m_Inventory.FindAction("SelectSlot3", throwIfNotFound: true);
        m_Inventory_SelectSlot4 = m_Inventory.FindAction("SelectSlot4", throwIfNotFound: true);
        m_Inventory_SelectSlot5 = m_Inventory.FindAction("SelectSlot5", throwIfNotFound: true);
        m_Inventory_SelectSlot6 = m_Inventory.FindAction("SelectSlot6", throwIfNotFound: true);
        m_Inventory_SelectSlot7 = m_Inventory.FindAction("SelectSlot7", throwIfNotFound: true);
        m_Inventory_SelectSlot8 = m_Inventory.FindAction("SelectSlot8", throwIfNotFound: true);
        m_Inventory_SelectSlot9 = m_Inventory.FindAction("SelectSlot9", throwIfNotFound: true);
        m_Inventory_SwitchInventoryVisibility = m_Inventory.FindAction("SwitchInventoryVisibility", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Looking;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Touch;
    private readonly InputAction m_Player_Bend;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Looking => m_Wrapper.m_Player_Looking;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Touch => m_Wrapper.m_Player_Touch;
        public InputAction @Bend => m_Wrapper.m_Player_Bend;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Looking.started += instance.OnLooking;
            @Looking.performed += instance.OnLooking;
            @Looking.canceled += instance.OnLooking;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Touch.started += instance.OnTouch;
            @Touch.performed += instance.OnTouch;
            @Touch.canceled += instance.OnTouch;
            @Bend.started += instance.OnBend;
            @Bend.performed += instance.OnBend;
            @Bend.canceled += instance.OnBend;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Looking.started -= instance.OnLooking;
            @Looking.performed -= instance.OnLooking;
            @Looking.canceled -= instance.OnLooking;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Touch.started -= instance.OnTouch;
            @Touch.performed -= instance.OnTouch;
            @Touch.canceled -= instance.OnTouch;
            @Bend.started -= instance.OnBend;
            @Bend.performed -= instance.OnBend;
            @Bend.canceled -= instance.OnBend;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Inventory
    private readonly InputActionMap m_Inventory;
    private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();
    private readonly InputAction m_Inventory_SelectSlot1;
    private readonly InputAction m_Inventory_SelectSlot2;
    private readonly InputAction m_Inventory_SelectSlot3;
    private readonly InputAction m_Inventory_SelectSlot4;
    private readonly InputAction m_Inventory_SelectSlot5;
    private readonly InputAction m_Inventory_SelectSlot6;
    private readonly InputAction m_Inventory_SelectSlot7;
    private readonly InputAction m_Inventory_SelectSlot8;
    private readonly InputAction m_Inventory_SelectSlot9;
    private readonly InputAction m_Inventory_SwitchInventoryVisibility;
    public struct InventoryActions
    {
        private @InputActions m_Wrapper;
        public InventoryActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectSlot1 => m_Wrapper.m_Inventory_SelectSlot1;
        public InputAction @SelectSlot2 => m_Wrapper.m_Inventory_SelectSlot2;
        public InputAction @SelectSlot3 => m_Wrapper.m_Inventory_SelectSlot3;
        public InputAction @SelectSlot4 => m_Wrapper.m_Inventory_SelectSlot4;
        public InputAction @SelectSlot5 => m_Wrapper.m_Inventory_SelectSlot5;
        public InputAction @SelectSlot6 => m_Wrapper.m_Inventory_SelectSlot6;
        public InputAction @SelectSlot7 => m_Wrapper.m_Inventory_SelectSlot7;
        public InputAction @SelectSlot8 => m_Wrapper.m_Inventory_SelectSlot8;
        public InputAction @SelectSlot9 => m_Wrapper.m_Inventory_SelectSlot9;
        public InputAction @SwitchInventoryVisibility => m_Wrapper.m_Inventory_SwitchInventoryVisibility;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void AddCallbacks(IInventoryActions instance)
        {
            if (instance == null || m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
            @SelectSlot1.started += instance.OnSelectSlot1;
            @SelectSlot1.performed += instance.OnSelectSlot1;
            @SelectSlot1.canceled += instance.OnSelectSlot1;
            @SelectSlot2.started += instance.OnSelectSlot2;
            @SelectSlot2.performed += instance.OnSelectSlot2;
            @SelectSlot2.canceled += instance.OnSelectSlot2;
            @SelectSlot3.started += instance.OnSelectSlot3;
            @SelectSlot3.performed += instance.OnSelectSlot3;
            @SelectSlot3.canceled += instance.OnSelectSlot3;
            @SelectSlot4.started += instance.OnSelectSlot4;
            @SelectSlot4.performed += instance.OnSelectSlot4;
            @SelectSlot4.canceled += instance.OnSelectSlot4;
            @SelectSlot5.started += instance.OnSelectSlot5;
            @SelectSlot5.performed += instance.OnSelectSlot5;
            @SelectSlot5.canceled += instance.OnSelectSlot5;
            @SelectSlot6.started += instance.OnSelectSlot6;
            @SelectSlot6.performed += instance.OnSelectSlot6;
            @SelectSlot6.canceled += instance.OnSelectSlot6;
            @SelectSlot7.started += instance.OnSelectSlot7;
            @SelectSlot7.performed += instance.OnSelectSlot7;
            @SelectSlot7.canceled += instance.OnSelectSlot7;
            @SelectSlot8.started += instance.OnSelectSlot8;
            @SelectSlot8.performed += instance.OnSelectSlot8;
            @SelectSlot8.canceled += instance.OnSelectSlot8;
            @SelectSlot9.started += instance.OnSelectSlot9;
            @SelectSlot9.performed += instance.OnSelectSlot9;
            @SelectSlot9.canceled += instance.OnSelectSlot9;
            @SwitchInventoryVisibility.started += instance.OnSwitchInventoryVisibility;
            @SwitchInventoryVisibility.performed += instance.OnSwitchInventoryVisibility;
            @SwitchInventoryVisibility.canceled += instance.OnSwitchInventoryVisibility;
        }

        private void UnregisterCallbacks(IInventoryActions instance)
        {
            @SelectSlot1.started -= instance.OnSelectSlot1;
            @SelectSlot1.performed -= instance.OnSelectSlot1;
            @SelectSlot1.canceled -= instance.OnSelectSlot1;
            @SelectSlot2.started -= instance.OnSelectSlot2;
            @SelectSlot2.performed -= instance.OnSelectSlot2;
            @SelectSlot2.canceled -= instance.OnSelectSlot2;
            @SelectSlot3.started -= instance.OnSelectSlot3;
            @SelectSlot3.performed -= instance.OnSelectSlot3;
            @SelectSlot3.canceled -= instance.OnSelectSlot3;
            @SelectSlot4.started -= instance.OnSelectSlot4;
            @SelectSlot4.performed -= instance.OnSelectSlot4;
            @SelectSlot4.canceled -= instance.OnSelectSlot4;
            @SelectSlot5.started -= instance.OnSelectSlot5;
            @SelectSlot5.performed -= instance.OnSelectSlot5;
            @SelectSlot5.canceled -= instance.OnSelectSlot5;
            @SelectSlot6.started -= instance.OnSelectSlot6;
            @SelectSlot6.performed -= instance.OnSelectSlot6;
            @SelectSlot6.canceled -= instance.OnSelectSlot6;
            @SelectSlot7.started -= instance.OnSelectSlot7;
            @SelectSlot7.performed -= instance.OnSelectSlot7;
            @SelectSlot7.canceled -= instance.OnSelectSlot7;
            @SelectSlot8.started -= instance.OnSelectSlot8;
            @SelectSlot8.performed -= instance.OnSelectSlot8;
            @SelectSlot8.canceled -= instance.OnSelectSlot8;
            @SelectSlot9.started -= instance.OnSelectSlot9;
            @SelectSlot9.performed -= instance.OnSelectSlot9;
            @SelectSlot9.canceled -= instance.OnSelectSlot9;
            @SwitchInventoryVisibility.started -= instance.OnSwitchInventoryVisibility;
            @SwitchInventoryVisibility.performed -= instance.OnSwitchInventoryVisibility;
            @SwitchInventoryVisibility.canceled -= instance.OnSwitchInventoryVisibility;
        }

        public void RemoveCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInventoryActions instance)
        {
            foreach (var item in m_Wrapper.m_InventoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnLooking(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnTouch(InputAction.CallbackContext context);
        void OnBend(InputAction.CallbackContext context);
    }
    public interface IInventoryActions
    {
        void OnSelectSlot1(InputAction.CallbackContext context);
        void OnSelectSlot2(InputAction.CallbackContext context);
        void OnSelectSlot3(InputAction.CallbackContext context);
        void OnSelectSlot4(InputAction.CallbackContext context);
        void OnSelectSlot5(InputAction.CallbackContext context);
        void OnSelectSlot6(InputAction.CallbackContext context);
        void OnSelectSlot7(InputAction.CallbackContext context);
        void OnSelectSlot8(InputAction.CallbackContext context);
        void OnSelectSlot9(InputAction.CallbackContext context);
        void OnSwitchInventoryVisibility(InputAction.CallbackContext context);
    }
}
