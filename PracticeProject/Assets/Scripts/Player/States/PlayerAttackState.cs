using System;
using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        PlayerController.Instance.Stop();
        PlayerAnimation.Instance.PlayAttack();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (!PlayerAnimation.Instance.IsPlaying(PlayerAnimateState.Attack))
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