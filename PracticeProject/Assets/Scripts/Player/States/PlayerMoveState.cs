using System;
using UnityEngine;

public class PlayerMoveState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        PlayerAnimation.Instance.PlayWalk();
    }

    public override void Update(PlayerStateManager manager)
    {
        var inputDirection = Input.GetAxis("Horizontal");
        if (!Equals(inputDirection, 0f))
        {
            PlayerController.Instance.Move(inputDirection);

            if (Input.GetKey(KeyCode.X))
            {
                manager.SwitchState(manager.jump_);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                manager.SwitchState(manager.attack_);
            }
        }
        else
        {
            manager.SwitchState(manager.idle_);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager manager, Collision2D collision)
    {
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