// GENERATED AUTOMATICALLY FROM 'Assets/_RagBall/NewScripts/ActionMap.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ActionMap : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @ActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ActionMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""fa67c669-e81a-4b5a-970f-14dac5e1cefb"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b2039bfb-61ae-4a06-9530-390946895b8b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GoLimp"",
                    ""type"": ""Button"",
                    ""id"": ""7de93337-6830-4ab5-bcba-015945d03adf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DirectThrow"",
                    ""type"": ""Button"",
                    ""id"": ""56b3ddeb-1f44-4fde-ba0e-76888ac6a700"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ArcThrow"",
                    ""type"": ""Button"",
                    ""id"": ""c49213a7-10cd-4f25-8b7e-b51bd46b7832"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4b0ad7cd-2823-4da7-989c-51b35b4f8808"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""GrabDrop"",
                    ""type"": ""Button"",
                    ""id"": ""6fb4f9e2-1da2-4afa-a6c9-df5159aed00d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""fa5b2664-523e-4af4-bed7-39c4931163a7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""05ae667a-5afb-4436-b426-bc8c7ccf59ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c32517ea-4e30-4789-9bad-2fb7ab0e489b"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e94c3829-011f-46fa-9b53-94afd10e8d83"",
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
                    ""id"": ""b44caf33-823d-493d-abfc-29c6e58a7f9c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4708740f-c777-4567-b9ec-d5243c0630fc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""68a56b53-2791-43f6-bf2d-b3b3f3b2bac8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8b7aebcf-e659-4d8f-8814-c1592cf95db1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""07f8d204-734f-4265-9230-8e54f97bcf67"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2c6407b-3af0-43b0-abfb-3bc6e6ba868d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27c5cc95-50f6-48f3-92e0-ccdcfd0988a8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""369d4959-dc79-42d0-806f-ffce21516be0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6efba1f-7b74-4a55-b144-778d82b7b674"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrabDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23987a5d-3d42-46e8-9091-736435caef23"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrabDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6dbdb19c-05a1-46ec-95c4-625ffd25f9e2"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35239f74-5d6f-4679-a0a6-f8cd0dda6dd1"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffad2369-72f3-4997-b1f1-6c354de94aac"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArcThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8bc45bb-8b58-4b70-8b30-167d6d4e0df3"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ArcThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""754b425d-8cb3-41f4-be92-9606a0779dce"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5223d4b0-06f6-4f64-9d33-f9d9f46fad17"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DirectThrow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6360a38c-8def-4664-a7e6-82b37bd8b038"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoLimp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96026412-ab38-4744-9f42-7ec97cd1ad8b"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoLimp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""437e6225-7b80-4abb-84ec-fc67e4a01281"",
            ""actions"": [
                {
                    ""name"": ""StartMenu"",
                    ""type"": ""Button"",
                    ""id"": ""735515bc-6ff9-4bbb-ab8a-bf264dd4ca44"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ProgressInMenu"",
                    ""type"": ""Button"",
                    ""id"": ""519ec513-175b-4310-8852-7bc581c90e0e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RegressInMenu"",
                    ""type"": ""Button"",
                    ""id"": ""619758bb-0266-4b6b-b766-3e3c2e5de41a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f92fd0e8-273e-42d2-83af-92d924908a2f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StartMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a8ee43b-a1ba-40c4-b0c3-b9cb3798f677"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ProgressInMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad3afe1a-682b-4c1d-a896-48b9ab1daf55"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RegressInMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_GoLimp = m_Player.FindAction("GoLimp", throwIfNotFound: true);
        m_Player_DirectThrow = m_Player.FindAction("DirectThrow", throwIfNotFound: true);
        m_Player_ArcThrow = m_Player.FindAction("ArcThrow", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_GrabDrop = m_Player.FindAction("GrabDrop", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_StartMenu = m_Menu.FindAction("StartMenu", throwIfNotFound: true);
        m_Menu_ProgressInMenu = m_Menu.FindAction("ProgressInMenu", throwIfNotFound: true);
        m_Menu_RegressInMenu = m_Menu.FindAction("RegressInMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_GoLimp;
    private readonly InputAction m_Player_DirectThrow;
    private readonly InputAction m_Player_ArcThrow;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_GrabDrop;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @ActionMap m_Wrapper;
        public PlayerActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @GoLimp => m_Wrapper.m_Player_GoLimp;
        public InputAction @DirectThrow => m_Wrapper.m_Player_DirectThrow;
        public InputAction @ArcThrow => m_Wrapper.m_Player_ArcThrow;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @GrabDrop => m_Wrapper.m_Player_GrabDrop;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @GoLimp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoLimp;
                @GoLimp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoLimp;
                @GoLimp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGoLimp;
                @DirectThrow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectThrow;
                @DirectThrow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectThrow;
                @DirectThrow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDirectThrow;
                @ArcThrow.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArcThrow;
                @ArcThrow.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArcThrow;
                @ArcThrow.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnArcThrow;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @GrabDrop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabDrop;
                @GrabDrop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabDrop;
                @GrabDrop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabDrop;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @GoLimp.started += instance.OnGoLimp;
                @GoLimp.performed += instance.OnGoLimp;
                @GoLimp.canceled += instance.OnGoLimp;
                @DirectThrow.started += instance.OnDirectThrow;
                @DirectThrow.performed += instance.OnDirectThrow;
                @DirectThrow.canceled += instance.OnDirectThrow;
                @ArcThrow.started += instance.OnArcThrow;
                @ArcThrow.performed += instance.OnArcThrow;
                @ArcThrow.canceled += instance.OnArcThrow;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @GrabDrop.started += instance.OnGrabDrop;
                @GrabDrop.performed += instance.OnGrabDrop;
                @GrabDrop.canceled += instance.OnGrabDrop;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_StartMenu;
    private readonly InputAction m_Menu_ProgressInMenu;
    private readonly InputAction m_Menu_RegressInMenu;
    public struct MenuActions
    {
        private @ActionMap m_Wrapper;
        public MenuActions(@ActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartMenu => m_Wrapper.m_Menu_StartMenu;
        public InputAction @ProgressInMenu => m_Wrapper.m_Menu_ProgressInMenu;
        public InputAction @RegressInMenu => m_Wrapper.m_Menu_RegressInMenu;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @StartMenu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartMenu;
                @StartMenu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartMenu;
                @StartMenu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStartMenu;
                @ProgressInMenu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnProgressInMenu;
                @ProgressInMenu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnProgressInMenu;
                @ProgressInMenu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnProgressInMenu;
                @RegressInMenu.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnRegressInMenu;
                @RegressInMenu.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnRegressInMenu;
                @RegressInMenu.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnRegressInMenu;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartMenu.started += instance.OnStartMenu;
                @StartMenu.performed += instance.OnStartMenu;
                @StartMenu.canceled += instance.OnStartMenu;
                @ProgressInMenu.started += instance.OnProgressInMenu;
                @ProgressInMenu.performed += instance.OnProgressInMenu;
                @ProgressInMenu.canceled += instance.OnProgressInMenu;
                @RegressInMenu.started += instance.OnRegressInMenu;
                @RegressInMenu.performed += instance.OnRegressInMenu;
                @RegressInMenu.canceled += instance.OnRegressInMenu;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnGoLimp(InputAction.CallbackContext context);
        void OnDirectThrow(InputAction.CallbackContext context);
        void OnArcThrow(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnGrabDrop(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnStartMenu(InputAction.CallbackContext context);
        void OnProgressInMenu(InputAction.CallbackContext context);
        void OnRegressInMenu(InputAction.CallbackContext context);
    }
}
