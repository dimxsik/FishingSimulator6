//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/GameInput/GameInput.inputactions
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

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""795e41de-1fc4-441f-a106-6989654332e1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""1f90b4e3-454f-491b-83e2-9d592c1671c8"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Looking"",
                    ""type"": ""PassThrough"",
                    ""id"": ""10b401d4-72b3-4702-8bb5-46a15c62c7f2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b45d4dc7-ff14-4af8-8217-2cb0bd5b8c73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Winding"",
                    ""type"": ""Button"",
                    ""id"": ""a8d11431-ce4c-423e-afcf-fe6d770173e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cast"",
                    ""type"": ""Button"",
                    ""id"": ""1827f40f-2b5b-43a0-895e-fa65c8b61ae8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hooking"",
                    ""type"": ""Button"",
                    ""id"": ""b8876fe3-74f9-489d-a0ab-26116094f751"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BobberDepthUp"",
                    ""type"": ""Button"",
                    ""id"": ""36842646-9a9e-4a5c-8ee6-49d27915a965"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BobberDepthDown"",
                    ""type"": ""Button"",
                    ""id"": ""1b41e6df-544d-491c-b04b-2902e9aa4942"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChooseBait"",
                    ""type"": ""Button"",
                    ""id"": ""a1f2e3ee-47ae-47a5-a500-97f631eb6672"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""dc9ae33e-3d7a-46d0-a93c-0a7ef5f339c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""592097ca-5f8e-4aa0-b636-26e6a2d6d9c7"",
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
                    ""id"": ""77293457-31e5-4ee9-aca4-6e7d2acc686d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bcf35dc9-ccf9-41be-9c06-b481f2867255"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8da36d1b-9914-4e03-8f85-46750532d0d2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3e3a52f4-86ed-469e-9602-0b57dc1d9bb0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8715ce5c-cfb3-4985-a003-1ba4285bb617"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Looking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36a88d94-d405-49c4-8883-4fa4bb3bdd6b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49e104ac-e728-4a60-bee7-0ce19871195b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Winding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52a710f5-2375-4db7-9846-a03b8632c2a8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Hooking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8e26cf1-7c80-46d5-9716-6306ce387e3d"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""BobberDepthUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efd62435-5d38-4b50-8a4b-bcc4292c35da"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BobberDepthDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26cf8ea9-f3c8-4550-95b2-d238fc5b0fb1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Cast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23e833d6-326a-49fa-9c64-64a9d42c0522"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""ChooseBait"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64b27bfe-968c-45ea-9310-9a8586f54d19"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Movement = m_Game.FindAction("Movement", throwIfNotFound: true);
        m_Game_Looking = m_Game.FindAction("Looking", throwIfNotFound: true);
        m_Game_Run = m_Game.FindAction("Run", throwIfNotFound: true);
        m_Game_Winding = m_Game.FindAction("Winding", throwIfNotFound: true);
        m_Game_Cast = m_Game.FindAction("Cast", throwIfNotFound: true);
        m_Game_Hooking = m_Game.FindAction("Hooking", throwIfNotFound: true);
        m_Game_BobberDepthUp = m_Game.FindAction("BobberDepthUp", throwIfNotFound: true);
        m_Game_BobberDepthDown = m_Game.FindAction("BobberDepthDown", throwIfNotFound: true);
        m_Game_ChooseBait = m_Game.FindAction("ChooseBait", throwIfNotFound: true);
        m_Game_Inventory = m_Game.FindAction("Inventory", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private List<IGameActions> m_GameActionsCallbackInterfaces = new List<IGameActions>();
    private readonly InputAction m_Game_Movement;
    private readonly InputAction m_Game_Looking;
    private readonly InputAction m_Game_Run;
    private readonly InputAction m_Game_Winding;
    private readonly InputAction m_Game_Cast;
    private readonly InputAction m_Game_Hooking;
    private readonly InputAction m_Game_BobberDepthUp;
    private readonly InputAction m_Game_BobberDepthDown;
    private readonly InputAction m_Game_ChooseBait;
    private readonly InputAction m_Game_Inventory;
    public struct GameActions
    {
        private @GameInput m_Wrapper;
        public GameActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Game_Movement;
        public InputAction @Looking => m_Wrapper.m_Game_Looking;
        public InputAction @Run => m_Wrapper.m_Game_Run;
        public InputAction @Winding => m_Wrapper.m_Game_Winding;
        public InputAction @Cast => m_Wrapper.m_Game_Cast;
        public InputAction @Hooking => m_Wrapper.m_Game_Hooking;
        public InputAction @BobberDepthUp => m_Wrapper.m_Game_BobberDepthUp;
        public InputAction @BobberDepthDown => m_Wrapper.m_Game_BobberDepthDown;
        public InputAction @ChooseBait => m_Wrapper.m_Game_ChooseBait;
        public InputAction @Inventory => m_Wrapper.m_Game_Inventory;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void AddCallbacks(IGameActions instance)
        {
            if (instance == null || m_Wrapper.m_GameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Looking.started += instance.OnLooking;
            @Looking.performed += instance.OnLooking;
            @Looking.canceled += instance.OnLooking;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
            @Winding.started += instance.OnWinding;
            @Winding.performed += instance.OnWinding;
            @Winding.canceled += instance.OnWinding;
            @Cast.started += instance.OnCast;
            @Cast.performed += instance.OnCast;
            @Cast.canceled += instance.OnCast;
            @Hooking.started += instance.OnHooking;
            @Hooking.performed += instance.OnHooking;
            @Hooking.canceled += instance.OnHooking;
            @BobberDepthUp.started += instance.OnBobberDepthUp;
            @BobberDepthUp.performed += instance.OnBobberDepthUp;
            @BobberDepthUp.canceled += instance.OnBobberDepthUp;
            @BobberDepthDown.started += instance.OnBobberDepthDown;
            @BobberDepthDown.performed += instance.OnBobberDepthDown;
            @BobberDepthDown.canceled += instance.OnBobberDepthDown;
            @ChooseBait.started += instance.OnChooseBait;
            @ChooseBait.performed += instance.OnChooseBait;
            @ChooseBait.canceled += instance.OnChooseBait;
            @Inventory.started += instance.OnInventory;
            @Inventory.performed += instance.OnInventory;
            @Inventory.canceled += instance.OnInventory;
        }

        private void UnregisterCallbacks(IGameActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Looking.started -= instance.OnLooking;
            @Looking.performed -= instance.OnLooking;
            @Looking.canceled -= instance.OnLooking;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
            @Winding.started -= instance.OnWinding;
            @Winding.performed -= instance.OnWinding;
            @Winding.canceled -= instance.OnWinding;
            @Cast.started -= instance.OnCast;
            @Cast.performed -= instance.OnCast;
            @Cast.canceled -= instance.OnCast;
            @Hooking.started -= instance.OnHooking;
            @Hooking.performed -= instance.OnHooking;
            @Hooking.canceled -= instance.OnHooking;
            @BobberDepthUp.started -= instance.OnBobberDepthUp;
            @BobberDepthUp.performed -= instance.OnBobberDepthUp;
            @BobberDepthUp.canceled -= instance.OnBobberDepthUp;
            @BobberDepthDown.started -= instance.OnBobberDepthDown;
            @BobberDepthDown.performed -= instance.OnBobberDepthDown;
            @BobberDepthDown.canceled -= instance.OnBobberDepthDown;
            @ChooseBait.started -= instance.OnChooseBait;
            @ChooseBait.performed -= instance.OnChooseBait;
            @ChooseBait.canceled -= instance.OnChooseBait;
            @Inventory.started -= instance.OnInventory;
            @Inventory.performed -= instance.OnInventory;
            @Inventory.canceled -= instance.OnInventory;
        }

        public void RemoveCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameActions instance)
        {
            foreach (var item in m_Wrapper.m_GameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameActions @Game => new GameActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface IGameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnLooking(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnWinding(InputAction.CallbackContext context);
        void OnCast(InputAction.CallbackContext context);
        void OnHooking(InputAction.CallbackContext context);
        void OnBobberDepthUp(InputAction.CallbackContext context);
        void OnBobberDepthDown(InputAction.CallbackContext context);
        void OnChooseBait(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
    }
}