using System;
using UnityEngine;

public abstract class PlayerStateBase
{
    public abstract void Enter(PlayerStateManager manager);

    public abstract void Update(PlayerStateManager manager);

    public abstract void OnCollisionEnter2D(PlayerStateManager manager, Collision2D collision);

    public abstract void OnTriggerEnter2D(PlayerStateManager manager, Collider2D collision);

    public abstract void OnCollisionExit2D(PlayerStateManager manager, Collision2D collision);

    public abstract void OnTriggerExit2D(PlayerStateManager manager, Collider2D collision);
}