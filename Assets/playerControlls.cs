// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControlls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControlls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""controlls"",
            ""id"": ""fe2acd34-0f06-46c8-83d2-2c4e970be107"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""56bdf5d2-6364-4a31-85a9-30dd025dbca4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""fire"",
                    ""type"": ""Button"",
                    ""id"": ""01b0fc48-9716-4675-935c-453932a7493b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""bcf1fb80-ea68-46bb-86ac-d36d8e7972db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9f355a44-fb60-463d-932a-1a6d4d84ff9c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1b5b781-8eb8-4cba-b2a2-526be112c420"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f870dda5-d893-4b79-b110-f807aa96c03b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // controlls
        m_controlls = asset.FindActionMap("controlls", throwIfNotFound: true);
        m_controlls_movement = m_controlls.FindAction("movement", throwIfNotFound: true);
        m_controlls_fire = m_controlls.FindAction("fire", throwIfNotFound: true);
        m_controlls_jump = m_controlls.FindAction("jump", throwIfNotFound: true);
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

    // controlls
    private readonly InputActionMap m_controlls;
    private IControllsActions m_ControllsActionsCallbackInterface;
    private readonly InputAction m_controlls_movement;
    private readonly InputAction m_controlls_fire;
    private readonly InputAction m_controlls_jump;
    public struct ControllsActions
    {
        private @PlayerControlls m_Wrapper;
        public ControllsActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_controlls_movement;
        public InputAction @fire => m_Wrapper.m_controlls_fire;
        public InputAction @jump => m_Wrapper.m_controlls_jump;
        public InputActionMap Get() { return m_Wrapper.m_controlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllsActions set) { return set.Get(); }
        public void SetCallbacks(IControllsActions instance)
        {
            if (m_Wrapper.m_ControllsActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnMovement;
                @fire.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnFire;
                @fire.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnFire;
                @fire.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnFire;
                @jump.started -= m_Wrapper.m_ControllsActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_ControllsActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_ControllsActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_ControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
                @fire.started += instance.OnFire;
                @fire.performed += instance.OnFire;
                @fire.canceled += instance.OnFire;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
            }
        }
    }
    public ControllsActions @controlls => new ControllsActions(this);
    public interface IControllsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
