using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OnButtonPress : MonoBehaviour
{
    [SerializeField]
    private InputAction action = null;

    [SerializeField]
    private UnityEvent OnPress = new UnityEvent();
    [SerializeField]
    private UnityEvent OnRelease = new UnityEvent();

    void Awake()
    {
        action.started += Pressed;
        action.canceled += Released;
    }

    void OnDestroy()
    {
        action.started -= Pressed;
        action.canceled -= Released;
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        OnPress.Invoke();
    }

    private void Released(InputAction.CallbackContext context)
    {
        OnRelease.Invoke();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
