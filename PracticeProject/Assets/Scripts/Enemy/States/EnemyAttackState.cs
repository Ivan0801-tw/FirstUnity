using System;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public override void Enter(EnemyStateManager manager)
    {
        EnemyController.Instance.Stop();
        EnemyAnimation.Instance.PlayAttack();
    }

    public override void Update(EnemyStateManager manager)
    {
        if (!EnemyAnimation.Instance.IsPlaying(EnemyAnimateState.Attack))
        {
            manager.SwitchState(manager.idle_);
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