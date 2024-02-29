using System;
using UnityEngine;

public class EnemyIdleState : EnemyStateBase
{
    public static event Action OnEnter;

    public override void Enter(EnemyStateManager manager)
    {
        Debug.Log("Enter Idle");
        OnEnter?.Invoke();
    }

    public override void Update(EnemyStateManager manager)
    {
        Collider2D[] collider;
        if (EnemyController.Instance.IsPlayerInRange(out collider))
        {
            manager.SwitchState(manager.attack_);
        }
        else
        {
            manager.SwitchState(manager.move_);
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