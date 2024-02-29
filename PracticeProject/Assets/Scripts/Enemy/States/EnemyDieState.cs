using System;
using UnityEngine;

public class EnemyDieState : EnemyStateBase
{
    public static event Action OnEnter;

    public override void Enter(EnemyStateManager manager)
    {
        Debug.Log("Enter Die");
        OnEnter?.Invoke();
    }

    public override void Update(EnemyStateManager manager)
    {
        if (!EnemyAnimation.Instance.IsPlaying(EnemyAnimateState.Die))
        {
            EnemyController.Instance.Destroy();
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