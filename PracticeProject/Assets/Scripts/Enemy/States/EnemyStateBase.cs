using System;
using UnityEngine;

public abstract class EnemyStateBase
{
    public abstract void Enter(EnemyStateManager manager);

    public abstract void Update(EnemyStateManager manager);

    public abstract void OnCollisionEnter2D(EnemyStateManager manager, Collision2D collision);

    public abstract void OnTriggerEnter2D(EnemyStateManager manager, Collider2D collision);

    public abstract void OnCollisionExit2D(EnemyStateManager manager, Collision2D collision);

    public abstract void OnTriggerExit2D(EnemyStateManager manager, Collider2D collision);
}