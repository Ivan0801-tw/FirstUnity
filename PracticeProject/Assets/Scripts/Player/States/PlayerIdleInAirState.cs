using System;
using UnityEngine;

public class PlayerIdleInAirState : PlayerStateBase
{
    private bool isInAir_ = false;

    public override void Enter(PlayerStateManager manager)
    {
        isInAir_ = true;
        PlayerAnimation.Instance.PlayInAir();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (!Equals(Input.GetAxis("Horizontal"), 0f))
        {
            manager.SwitchState(manager.moveInAir_);
        }
        else if (!isInAir_)
        {
            manager.SwitchState(manager.idle_);
        }
    }

    public override void OnCollisionEnter2D(PlayerStateManager manager, Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Ground.ToString()))
        {
            isInAir_ = false;
        }
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