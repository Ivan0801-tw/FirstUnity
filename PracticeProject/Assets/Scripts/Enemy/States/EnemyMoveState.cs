using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMoveState : EnemyStateBase
{
    public override void Enter(EnemyStateManager manager)
    {
        EnemyAnimation.Instance.PlayWalk();
    }

    public override void Update(EnemyStateManager manager)
    {
        var target = PlayerStatus.Instance.LocalPosition;
        var current = manager.status_.LocalPosition;
        var deltaX = target.x - current.x;

        if (Math.Abs(deltaX) <= manager.status_.StopTrackRange)
        {
            if (deltaX < 0 && manager.status_.IsFacingRight)
            {
                manager.status_.IsFacingRight = false;
            }
            manager.controller_.Stop();
            manager.SwitchState(manager.idle_);
        }
        else
        {
            var direction = new Vector2(deltaX, 0).normalized;
            manager.controller_.Move(direction.x);
        }
    }

    public override void OnCollisionEnter2D(EnemyStateManager manager, Collision2D collision)
    {
    }

    public override void OnCollisionExit2D(EnemyStateManager manager, Collision2D collision)
    {
    }

    public override void OnTriggerEnter2D(EnemyStateManager manager, Collider2D collision)
    {
    }

    public override void OnTriggerExit2D(EnemyStateManager manager, Collider2D collision)
    {
    }
}