using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController_CSharp : IFixedTickable
{
    [Inject(Id = "Player")] private IInput _input;
    [Inject(Id = "Player")] private IStatus _status;
    [Inject(Id = "Player")] private IGround _ground;
    [Inject(Id = "Player")] private Transform _transform;
    [Inject(Id = "Player")] private Rigidbody2D _rigidbody;

    public void FixedTick()
    {
        HorizontalMove();
        Attack();
        Jump();
    }

    private void HorizontalMove()
    {
        Vector2 movement = _input.GetMovement();
        _rigidbody.velocity = new Vector2(movement.normalized.x * _status.MoveSpeed, _rigidbody.velocity.y);
    }

    private void Attack()
    {
        if (!_input.GetAttack())
        {
            return;
        }

        switch (_input.GetAttackDirection())
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
        if (_input.GetJump())
        {
            _status.JumpBufferTimer = _status.JumpBufferTime;
        }
        else if (_status.JumpBufferTimer > 0f)
        {
            _status.JumpBufferTimer -= Time.deltaTime;
        }

        if (_status.JumpBufferTimer > 0f && _ground.IsGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _status.JumpForce);
            _status.JumpBufferTimer = 0f;
        }
    }
}