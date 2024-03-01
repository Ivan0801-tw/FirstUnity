using System;
using UnityEngine;

public class EnemyDieState : EnemyStateBase
{
    public override void Enter(EnemyStateManager manager)
    {
        manager.animation_.PlayDie();
    }

    public override void Update(EnemyStateManager manager)
    {
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