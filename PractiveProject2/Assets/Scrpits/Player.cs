using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    private PlayerInputAction _input;
    private Vector2 _inputVector = Vector2.zero;

    [Header("GroundCheck")]
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private float _groundOffsetRadius;
    [SerializeField] private LayerMask _groundLayerMask;

    [Header("Movement")]
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;

    [Header("Status")]
    [SerializeField] private bool _isJumping = false;
    [SerializeField] private bool _isGrounded = false;

    private void Awake()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();
        _input.Player.Attack.performed += Attack_performed;
        _input.Player.Jump.performed += Jump_performed;
    }

    private void FixedUpdate()
    {
        UpdateStatus();
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
        if (_isGrounded && !_isJumping)
        {
            _isJumping = true;
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundPoint.position, _groundOffsetRadius, _groundLayerMask);
    }

    private void UpdateStatus()
    {
        _isGrounded = IsGrounded();
        if (_isGrounded && _isJumping && _rigidbody.velocity.y <= 0)
        {
            _isJumping = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(_groundPoint.position, _groundOffsetRadius);
    }
}