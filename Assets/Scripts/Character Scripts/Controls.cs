//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Character Scripts/Controls.inputactions
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

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Sewers"",
            ""id"": ""49cba3a1-1be7-49ab-a5b4-f0527c5f3206"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""71237a8e-6ffe-49f6-89b2-c4bf04db33b8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4e7d9687-0c2b-4187-880b-b6de54110aa0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""273c83de-624f-4497-923c-88ebf8af758c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f487ec69-27c0-4c61-ac0d-c24c7c987d72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""85c31781-8dc8-4138-b27a-4d4a552a72b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchItem"",
                    ""type"": ""Button"",
                    ""id"": ""708f524a-44c9-422e-b346-d85c02635d62"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""Button"",
                    ""id"": ""9b7de6a9-53bf-424b-a49b-981fbce80cd9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HotbarScroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5f075006-4c1b-48fe-b035-f048c1d56779"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HotbarSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""d5e8d147-eee3-4703-a535-817d269df02c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c168fac7-7baf-4689-b11e-c3f48f73dff4"",
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
                    ""id"": ""a5e42d26-742c-4624-9d58-0eba70148f46"",
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
                    ""id"": ""a5444cd6-225c-4785-be10-bc2c839ca419"",
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
                    ""id"": ""daf77edb-11e1-46dc-86fc-3b0c25d4d9f8"",
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
                    ""id"": ""16f20fbc-df20-48cc-aa11-d0a266f4ed1a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""567442ed-6afd-498a-b85a-c02d6f5b4cee"",
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
                    ""id"": ""efc8f3b8-3b4a-4d05-af40-c47d0a1f05b2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""489a58d7-21ef-4df6-b1a1-1bfaa79a259c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""57c3ee1d-0ee5-448f-b719-ea41a93b674b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b57817be-f2a2-4a4b-b399-a3147a9d4cd5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""da20f0f8-39ed-427b-b81c-60e0d0f9af9a"",
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
                    ""id"": ""af0b92e1-b34e-4511-8f82-285431165ad0"",
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
                    ""id"": ""b0144f24-d572-440f-8519-f6651de0da4d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d33348be-b028-479f-8f9c-b267d0c08dc9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94942dbe-a35f-4857-8759-f37590e27337"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwitchItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74b68cda-6f99-4acb-a6b6-88cc54669e5d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""167304da-6672-4b0d-b947-9d8f17fc30c3"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bf472dc2-8ae9-4854-809e-1cd9280478a5"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7860533-5696-414b-8fb4-70294cff2127"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69d85b3c-df80-444b-9b57-48b56912e9f8"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cc5c810-f0af-4141-8e11-7d15901d7136"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e740900-e74a-440c-a893-233335998a09"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0adb94c4-37d7-43a2-994e-779b44f925bb"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=6)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0399e2e9-c2af-46fa-bdd6-c52627722f74"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=7)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a853f081-c280-40db-ba40-f2e1fdfeb152"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=8)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcd687a0-d4ee-4132-bbae-ef312a269375"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=9)"",
                    ""groups"": """",
                    ""action"": ""HotbarSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Sewers
        m_Sewers = asset.FindActionMap("Sewers", throwIfNotFound: true);
        m_Sewers_Move = m_Sewers.FindAction("Move", throwIfNotFound: true);
        m_Sewers_Jump = m_Sewers.FindAction("Jump", throwIfNotFound: true);
        m_Sewers_Look = m_Sewers.FindAction("Look", throwIfNotFound: true);
        m_Sewers_Pause = m_Sewers.FindAction("Pause", throwIfNotFound: true);
        m_Sewers_Throw = m_Sewers.FindAction("Throw", throwIfNotFound: true);
        m_Sewers_SwitchItem = m_Sewers.FindAction("SwitchItem", throwIfNotFound: true);
        m_Sewers_Swing = m_Sewers.FindAction("Swing", throwIfNotFound: true);
        m_Sewers_HotbarScroll = m_Sewers.FindAction("HotbarScroll", throwIfNotFound: true);
        m_Sewers_HotbarSwitch = m_Sewers.FindAction("HotbarSwitch", throwIfNotFound: true);
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

    // Sewers
    private readonly InputActionMap m_Sewers;
    private List<ISewersActions> m_SewersActionsCallbackInterfaces = new List<ISewersActions>();
    private readonly InputAction m_Sewers_Move;
    private readonly InputAction m_Sewers_Jump;
    private readonly InputAction m_Sewers_Look;
    private readonly InputAction m_Sewers_Pause;
    private readonly InputAction m_Sewers_Throw;
    private readonly InputAction m_Sewers_SwitchItem;
    private readonly InputAction m_Sewers_Swing;
    private readonly InputAction m_Sewers_HotbarScroll;
    private readonly InputAction m_Sewers_HotbarSwitch;
    public struct SewersActions
    {
        private @Controls m_Wrapper;
        public SewersActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Sewers_Move;
        public InputAction @Jump => m_Wrapper.m_Sewers_Jump;
        public InputAction @Look => m_Wrapper.m_Sewers_Look;
        public InputAction @Pause => m_Wrapper.m_Sewers_Pause;
        public InputAction @Throw => m_Wrapper.m_Sewers_Throw;
        public InputAction @SwitchItem => m_Wrapper.m_Sewers_SwitchItem;
        public InputAction @Swing => m_Wrapper.m_Sewers_Swing;
        public InputAction @HotbarScroll => m_Wrapper.m_Sewers_HotbarScroll;
        public InputAction @HotbarSwitch => m_Wrapper.m_Sewers_HotbarSwitch;
        public InputActionMap Get() { return m_Wrapper.m_Sewers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SewersActions set) { return set.Get(); }
        public void AddCallbacks(ISewersActions instance)
        {
            if (instance == null || m_Wrapper.m_SewersActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SewersActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
            @SwitchItem.started += instance.OnSwitchItem;
            @SwitchItem.performed += instance.OnSwitchItem;
            @SwitchItem.canceled += instance.OnSwitchItem;
            @Swing.started += instance.OnSwing;
            @Swing.performed += instance.OnSwing;
            @Swing.canceled += instance.OnSwing;
            @HotbarScroll.started += instance.OnHotbarScroll;
            @HotbarScroll.performed += instance.OnHotbarScroll;
            @HotbarScroll.canceled += instance.OnHotbarScroll;
            @HotbarSwitch.started += instance.OnHotbarSwitch;
            @HotbarSwitch.performed += instance.OnHotbarSwitch;
            @HotbarSwitch.canceled += instance.OnHotbarSwitch;
        }

        private void UnregisterCallbacks(ISewersActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
            @SwitchItem.started -= instance.OnSwitchItem;
            @SwitchItem.performed -= instance.OnSwitchItem;
            @SwitchItem.canceled -= instance.OnSwitchItem;
            @Swing.started -= instance.OnSwing;
            @Swing.performed -= instance.OnSwing;
            @Swing.canceled -= instance.OnSwing;
            @HotbarScroll.started -= instance.OnHotbarScroll;
            @HotbarScroll.performed -= instance.OnHotbarScroll;
            @HotbarScroll.canceled -= instance.OnHotbarScroll;
            @HotbarSwitch.started -= instance.OnHotbarSwitch;
            @HotbarSwitch.performed -= instance.OnHotbarSwitch;
            @HotbarSwitch.canceled -= instance.OnHotbarSwitch;
        }

        public void RemoveCallbacks(ISewersActions instance)
        {
            if (m_Wrapper.m_SewersActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISewersActions instance)
        {
            foreach (var item in m_Wrapper.m_SewersActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SewersActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SewersActions @Sewers => new SewersActions(this);
    public interface ISewersActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnSwitchItem(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
        void OnHotbarScroll(InputAction.CallbackContext context);
        void OnHotbarSwitch(InputAction.CallbackContext context);
    }
}
