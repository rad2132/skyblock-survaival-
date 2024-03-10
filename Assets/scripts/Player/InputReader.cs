using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public static PlayerInputReader Instance;
    private PlayerController _controller;
    private bool _isGettingInput;
    private Vector2 _movementInput;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_isGettingInput)
        {
            _controller.Move(_movementInput);
        }
    }
    public void OnMovementTriggered(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isGettingInput = true;
            Vector2 input = context.ReadValue<Vector2>().normalized;
            _movementInput = input;
        }
        if (context.canceled)
        {
            _isGettingInput = false;
            _controller.Move(Vector2.zero);
        }
    }

    public void OnLookingTriggered(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>().normalized;
            _controller.LookAroundPC(input);
        }
        if (context.canceled)
        {
            _controller.LookAroundPC(Vector2.zero);
        }
    }

    public void OnJumpTriggered(InputAction.CallbackContext context)
    {
        if (context.performed || context.canceled)
        {
            _controller.Jump();
        }
    }
    public void OnBendTriggered(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _controller.Bend();
        }
    }
}
