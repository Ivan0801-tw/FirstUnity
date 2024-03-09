using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private PlayerInputAction _input;
    private Vector2 _inputVector = Vector2.zero;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
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
        _rigidbody.velocity = new Vector2(_inputVector.normalized.x * _speed, _rigidbody.velocity.y);
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        float yInput = _inputVector.normalized.y;
        if (yInput > 0)
        {
            Debug.Log("Attack Up");
        }
        else if (yInput < 0)
        {
            Debug.Log("Attacke Down");
        }
        else
        {
            Debug.Log("Attacke Front");
        }
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}