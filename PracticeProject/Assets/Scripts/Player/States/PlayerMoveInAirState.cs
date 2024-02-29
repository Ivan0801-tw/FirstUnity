using System;
using UnityEngine;

public class PlayerMoveInAirState : PlayerStateBase
{
    private bool isInAir_ = false;

    public static event Action OnEnter;

    public override void Enter(PlayerStateManager manager)
    {
        OnEnter?.Invoke();
        isInAir_ = true;
    }

    public override void Update(PlayerStateManager manager)
    {
        var inputDirection = Input.GetAxis("Horizontal");
        if (!Equals(inputDirection, 0f))
        {
            PlayerController.Instance.Move(inputDirection);

            if (!isInAir_)
            {
                manager.SwitchState(manager.move_);
            }
        }
        else
        {
            manager.SwitchState(manager.idleInAir_);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager manager, Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ground.ToString()))
        {
            isInAir_ = false;
        }
    }

    public override void OnCollisionExit2D(PlayerStateManager manager, Collision2D collision)
    {
    }

    public override void OnTriggerEnter2D(PlayerStateManager manager, Collider2D collision)
    {
    }

    public override void OnTriggerExit2D(PlayerStateManager manager, Collider2D collision)
    {
    }
}