using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Zenject;

public class PlayerInput_CSharp : IInput
{
    public Vector2 _movement = Vector2.zero;
    public AttackDriection _attackDirection = AttackDriection.Front;
    private bool _isAttack = false;
    private bool _isJump = false;

    private PlayerInputAction _input;

    public PlayerInput_CSharp()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();
        _input.Player.Movement.performed += Movement_performed;
        _input.Player.Movement.canceled += Movement_canceled;

        _input.Player.Attack.performed += Attack_performed;
        _input.Player.Attack.canceled += Attack_canceled;

        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Jump.canceled += Jump_canceled;
    }

    ~PlayerInput_CSharp()
    {
        _input.Player.Disable();
        _input.Player.Movement.performed -= Movement_performed;
        _input.Player.Movement.canceled -= Movement_canceled;

        _input.Player.Attack.performed -= Attack_performed;
        _input.Player.Attack.canceled -= Attack_canceled;

        _input.Player.Jump.performed -= Jump_performed;
        _input.Player.Jump.canceled -= Jump_canceled;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        if (_movement.y > 0)
        {
            _attackDirection = AttackDriection.Up;
        }
        else if (_movement.y < 0)
        {
            _attackDirection = AttackDriection.Down;
        }
        else
        {
            _attackDirection = AttackDriection.Front;
        }
    }

    private void Movement_canceled(InputAction.CallbackContext context)
    {
        _movement = Vector2.zero;
        _attackDirection = AttackDriection.Front;
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        _isAttack = true;
    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {
        _isAttack = false;
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        _isJump = true;
    }

    private void Jump_canceled(InputAction.CallbackContext context)
    {
        _isJump = false;
    }

    public Vector2 GetMovement()
    {
        return _movement;
    }

    public bool GetJump()
    {
        var isJump = _isJump;
        if (isJump)
        {
            _isJump = false;
        }
        return isJump;
    }

    public AttackDriection GetAttackDirection()
    {
        return _attackDirection;
    }

    public bool GetAttack()
    {
        var isAttack = _isAttack;
        if (isAttack)
        {
            _isAttack = false;
        }
        return isAttack;
    }
}