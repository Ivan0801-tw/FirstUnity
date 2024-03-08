using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerInputAction _input;
    private Vector2 _inputVector = Vector2.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = new PlayerInputAction();
        _input.Player.Enable();
        _input.Player.Attack.performed += Attack_performed;
        _input.Player.Jump.performed += Jump_performed;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        _inputVector = _input.Player.Movement.ReadValue<Vector2>();
        if (_inputVector.Equals(Vector2.zero))
        {
            return;
        }
        else if (_inputVector.Equals(Vector2.up))
        {
            Debug.Log("Look Up");
        }
        else if (_inputVector.Equals(Vector2.down))
        {
            Debug.Log("Look Down");
        }
        else if (_inputVector.Equals(Vector2.left) ||
           _inputVector.Equals(Vector2.right))
        {
            _rigidbody.AddForce(_inputVector, ForceMode2D.Impulse);
        }
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Attacke Performed");
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump Performed");
    }
}