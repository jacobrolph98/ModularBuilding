// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""CameraControl"",
            ""id"": ""15064e90-ff07-417c-a33e-75744b01ce3a"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""984a980a-e755-4c6b-85fd-a4188d3db311"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Verticality"",
                    ""type"": ""Value"",
                    ""id"": ""3426652d-a91f-4cca-b618-63e943cce77d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShapeMenu"",
                    ""type"": ""Button"",
                    ""id"": ""39128741-1cd4-44a1-bc0a-6b39ea1b88d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""48db5bc5-7995-49c1-8fec-e51263857bb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockAndMove"",
                    ""type"": ""Button"",
                    ""id"": ""25517827-99bd-466b-a60a-be97ea23a25a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""PassThrough"",
                    ""id"": ""88fb2df9-2084-4c40-b54c-886ddf566dc4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""64abf287-dddc-4eba-b398-4427ee490b13"",
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
                    ""id"": ""b972b742-518f-4b5e-9054-46ff328affbf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6ce81fe2-a216-497d-b740-e5f2dec13fee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ed12614a-9e69-4288-a8fd-87231e342cbb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""838bab32-950d-42c5-a663-f2244040fdef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f92430a1-80cb-4b00-826d-c19a2586f6bc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Verticality"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cc36f421-49dc-40cf-ac2c-f1966410947b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Verticality"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3c53a19b-fa87-41c9-bf00-ee01cbd368bd"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Verticality"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ca4d2ae1-73ed-4dbb-a16a-2019a48e526a"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""ShapeMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ac3c5e0-3773-413e-99fb-cf5fe96bd766"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21aeacc5-86f6-4793-a8d7-50c1d733de25"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""LockAndMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92766572-12b1-4115-b442-d6a830d75a75"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KBM"",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KBM"",
            ""bindingGroup"": ""KBM"",
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
        // CameraControl
        m_CameraControl = asset.FindActionMap("CameraControl", throwIfNotFound: true);
        m_CameraControl_Movement = m_CameraControl.FindAction("Movement", throwIfNotFound: true);
        m_CameraControl_Verticality = m_CameraControl.FindAction("Verticality", throwIfNotFound: true);
        m_CameraControl_ShapeMenu = m_CameraControl.FindAction("ShapeMenu", throwIfNotFound: true);
        m_CameraControl_Interact = m_CameraControl.FindAction("Interact", throwIfNotFound: true);
        m_CameraControl_LockAndMove = m_CameraControl.FindAction("LockAndMove", throwIfNotFound: true);
        m_CameraControl_MouseMove = m_CameraControl.FindAction("MouseMove", throwIfNotFound: true);
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

    // CameraControl
    private readonly InputActionMap m_CameraControl;
    private ICameraControlActions m_CameraControlActionsCallbackInterface;
    private readonly InputAction m_CameraControl_Movement;
    private readonly InputAction m_CameraControl_Verticality;
    private readonly InputAction m_CameraControl_ShapeMenu;
    private readonly InputAction m_CameraControl_Interact;
    private readonly InputAction m_CameraControl_LockAndMove;
    private readonly InputAction m_CameraControl_MouseMove;
    public struct CameraControlActions
    {
        private @PlayerInputActions m_Wrapper;
        public CameraControlActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CameraControl_Movement;
        public InputAction @Verticality => m_Wrapper.m_CameraControl_Verticality;
        public InputAction @ShapeMenu => m_Wrapper.m_CameraControl_ShapeMenu;
        public InputAction @Interact => m_Wrapper.m_CameraControl_Interact;
        public InputAction @LockAndMove => m_Wrapper.m_CameraControl_LockAndMove;
        public InputAction @MouseMove => m_Wrapper.m_CameraControl_MouseMove;
        public InputActionMap Get() { return m_Wrapper.m_CameraControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraControlActions set) { return set.Get(); }
        public void SetCallbacks(ICameraControlActions instance)
        {
            if (m_Wrapper.m_CameraControlActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMovement;
                @Verticality.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnVerticality;
                @Verticality.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnVerticality;
                @Verticality.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnVerticality;
                @ShapeMenu.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnShapeMenu;
                @ShapeMenu.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnShapeMenu;
                @ShapeMenu.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnShapeMenu;
                @Interact.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnInteract;
                @LockAndMove.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLockAndMove;
                @LockAndMove.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLockAndMove;
                @LockAndMove.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnLockAndMove;
                @MouseMove.started -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMouseMove;
                @MouseMove.performed -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMouseMove;
                @MouseMove.canceled -= m_Wrapper.m_CameraControlActionsCallbackInterface.OnMouseMove;
            }
            m_Wrapper.m_CameraControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Verticality.started += instance.OnVerticality;
                @Verticality.performed += instance.OnVerticality;
                @Verticality.canceled += instance.OnVerticality;
                @ShapeMenu.started += instance.OnShapeMenu;
                @ShapeMenu.performed += instance.OnShapeMenu;
                @ShapeMenu.canceled += instance.OnShapeMenu;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @LockAndMove.started += instance.OnLockAndMove;
                @LockAndMove.performed += instance.OnLockAndMove;
                @LockAndMove.canceled += instance.OnLockAndMove;
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
            }
        }
    }
    public CameraControlActions @CameraControl => new CameraControlActions(this);
    private int m_KBMSchemeIndex = -1;
    public InputControlScheme KBMScheme
    {
        get
        {
            if (m_KBMSchemeIndex == -1) m_KBMSchemeIndex = asset.FindControlSchemeIndex("KBM");
            return asset.controlSchemes[m_KBMSchemeIndex];
        }
    }
    public interface ICameraControlActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnVerticality(InputAction.CallbackContext context);
        void OnShapeMenu(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLockAndMove(InputAction.CallbackContext context);
        void OnMouseMove(InputAction.CallbackContext context);
    }
}
