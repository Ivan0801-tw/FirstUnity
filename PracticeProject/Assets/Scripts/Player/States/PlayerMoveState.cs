using System;
using UnityEngine;

public class PlayerMoveState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        PlayerAnimation.Instance.PlayWalk();
        PlayerSFX.Instance.PlayWalk();
    }

    public override void Update(PlayerStateManager manager)
    {
        Vector2 vector;
        if (manager.IsInputMove(out vector))
        {
            manager.controller_.Move(vector.x);

            if (manager.inputActions_.Player.Jump.triggered)
            {
                manager.SwitchState(manager.jump_);
            }
            else if (manager.inputActions_.Player.Attack.triggered)
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