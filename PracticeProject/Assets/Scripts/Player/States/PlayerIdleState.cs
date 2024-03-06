using System;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        manager.controller_.Stop();
        PlayerAnimation.Instance.PlayIdle();
        PlayerSFX.Instance.StopPlaying();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (manager.IsInputMove(out _))
        {
            manager.SwitchState(manager.move_);
        }
        else if (manager.inputActions_.Player.Jump.triggered)
        {
            manager.SwitchState(manager.jump_);
        }
        else if (manager.inputActions_.Player.Attack.triggered)
        {
            manager.SwitchState(manager.attack_);
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