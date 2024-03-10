using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public enum AttackDriection
{
    Up,
    Front,
    Down,
}

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 Movement { get; private set; } = Vector2.zero;
    public AttackDriection AttackDirection { get; private set; } = AttackDriection.Front;

    public bool Attack
    {
        get
        {
            var value = _attack;
            if (value == true)
            {
                _attack = false;
            }
            return value;
        }
        private set
        {
            _attack = value;
        }
    }

    private bool _attack = false;

    public bool Jump
    {
        get
        {
            var value = _jump;
            if (value == true)
            {
                _jump = false;
            }
            return value;
        }
        private set
        {
            _jump = value;
        }
    }

    private bool _jump = false;

    private PlayerInputAction _input;

    private void Awake()
    {
        _input = new PlayerInputAction();
    }

    private void OnEnable()
    {
        _input.Player.Enable();
        _input.Player.Movement.performed += Movement_performed;
        _input.Player.Movement.canceled += Movement_canceled;

        _input.Player.Attack.performed += Attack_performed;
        _input.Player.Attack.canceled += Attack_canceled;

        _input.Player.Jump.performed += Jump_performed;
        _input.Player.Jump.canceled += Jump_canceled;
    }

    private void OnDisable()
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
        Movement = context.ReadValue<Vector2>();
        if (Movement.y > 0)
        {
            AttackDirection = AttackDriection.Up;
        }
        else if (Movement.y < 0)
        {
            AttackDirection = AttackDriection.Down;
        }
        else
        {
            AttackDirection = AttackDriection.Front;
        }
    }

    private void Movement_canceled(InputAction.CallbackContext context)
    {
        Movement = Vector2.zero;
        AttackDirection = AttackDriection.Front;
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        Attack = true;
    }

    private void Attack_canceled(InputAction.CallbackContext context)
    {
        Attack = false;
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        Jump = true;
    }

    private void Jump_canceled(InputAction.CallbackContext context)
    {
        Jump = false;
    }
}