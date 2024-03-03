using System;
using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        manager.controller_.Jump();
        PlayerAnimation.Instance.PlayJump();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (manager.IsInputMove(out _))
        {
            manager.SwitchState(manager.moveInAir_);
        }
        else
        {
            manager.SwitchState(manager.idleInAir_);
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