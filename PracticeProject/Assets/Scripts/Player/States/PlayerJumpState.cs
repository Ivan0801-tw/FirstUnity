using System;
using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public static event Action OnEnter;

    public override void Enter(PlayerStateManager manager)
    {
        OnEnter?.Invoke();
        PlayerController.Instance.Jump();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (!Equals(Input.GetAxis("Horizontal"), 0f))
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