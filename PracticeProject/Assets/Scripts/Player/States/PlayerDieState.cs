using System;
using UnityEngine;

public class PlayerDieState : PlayerStateBase
{
    public override void Enter(PlayerStateManager manager)
    {
        PlayerAnimation.Instance.PlayDie();
        PlayerSFX.Instance.PlayDie();
    }

    public override void Update(PlayerStateManager manager)
    {
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