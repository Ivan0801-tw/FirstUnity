using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private PlayerInputHandler _inputHandler;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private float _groundOffsetRadius;
    [SerializeField] private LayerMask _groundLayerMask;

    [Header("Movement")]
    [SerializeField] private float _jumpForce = 75f;
    [SerializeField] private float _speed = 5f;

    [Header("Status")]
    [SerializeField] private bool _isGrounded = false;

    [Header("Jump Buffer")]
    [SerializeField] private float _jumpBufferTime = 0.25f;
    [SerializeField] private float _jumpBufferTimer = 0f;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        UpdateStatus();
        Movement();
        Attack();
        Jump();
    }

    private void Movement()
    {
        _rigidbody.velocity = new Vector2(_inputHandler.Movement.normalized.x * _speed, _rigidbody.velocity.y);
    }

    private void Attack()
    {
        if (!_inputHandler.Attack)
        {
            return;
        }
        switch (_inputHandler.AttackDirection)
        {
            case AttackDriection.Up:
                Debug.Log("Attack Up");
                break;

            case AttackDriection.Front:
                Debug.Log("Attacke Front");
                break;

            case AttackDriection.Down:
                Debug.Log("Attacke Down");
                break;
        }
    }

    private void Jump()
    {
        var isJumpThisFrame = _inputHandler.Jump;

        if (isJumpThisFrame)
        {
            _jumpBufferTimer = _jumpBufferTime;
        }
        else if (_jumpBufferTimer > 0f)
        {
            _jumpBufferTimer -= Time.deltaTime;
        }

        if (_jumpBufferTimer > 0f && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _jumpBufferTimer = 0f;
        }
    }

    private void UpdateStatus()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundPoint.position, _groundOffsetRadius, _groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(_groundPoint.position, _groundOffsetRadius);
    }
}