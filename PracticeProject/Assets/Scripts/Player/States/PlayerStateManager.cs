using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerStateBase currentState_;

    public readonly PlayerIdleState idle_ = new PlayerIdleState();
    public readonly PlayerMoveState move_ = new PlayerMoveState();
    public readonly PlayerJumpState jump_ = new PlayerJumpState();
    public readonly PlayerIdleInAirState idleInAir_ = new PlayerIdleInAirState();
    public readonly PlayerMoveInAirState moveInAir_ = new PlayerMoveInAirState();
    public readonly PlayerAttackState attack_ = new PlayerAttackState();
    public readonly PlayerDieState die_ = new PlayerDieState();

    private void Start()
    {
        SwitchState(idle_);
    }

    private void Update()
    {
        currentState_.Update(this);
    }

    public void SwitchState(PlayerStateBase state)
    {
        currentState_ = state;
        currentState_.Enter(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState_.OnCollisionEnter2D(this, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState_.OnCollisionExit2D(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState_.OnTriggerEnter2D(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState_.OnTriggerExit2D(this, collision);
    }
}