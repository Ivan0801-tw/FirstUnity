using System;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    public static event Action OnEnter;

    public override void Enter(PlayerStateManager manager)
    {
        Debug.Log("Enter Idle");
        OnEnter?.Invoke();
    }

    public override void Update(PlayerStateManager manager)
    {
        if (PlayerStatus.Instance.Hp <= 0)
        {
            manager.SwitchState(manager.die_);
        }
        else if (!Equals(Input.GetAxis("Horizontal"), 0f))
        {
            manager.SwitchState(manager.move_);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            manager.SwitchState(manager.jump_);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            manager.SwitchState(manager.attack_);
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