using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerStateBase currentState_;
    private bool isDead_ = false;
    public PlayerController controller_ { get; private set; }
    public PlayerInputActions inputActions_ { get; private set; }

    public readonly PlayerIdleState idle_ = new PlayerIdleState();
    public readonly PlayerMoveState move_ = new PlayerMoveState();
    public readonly PlayerJumpState jump_ = new PlayerJumpState();
    public readonly PlayerIdleInAirState idleInAir_ = new PlayerIdleInAirState();
    public readonly PlayerMoveInAirState moveInAir_ = new PlayerMoveInAirState();
    public readonly PlayerAttackState attack_ = new PlayerAttackState();
    public readonly PlayerDieState die_ = new PlayerDieState();

    private void Awake()
    {
        controller_ = GetComponent<PlayerController>();
        inputActions_ = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions_.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions_.Player.Disable();
    }

    private void Start()
    {
        SwitchState(idle_);
    }

    private void Update()
    {
        if (!isDead_ && PlayerStatus.Instance.Hp <= 0)
        {
            isDead_ = true;
            SwitchState(die_);
        }
        currentState_.Update(this);
    }

    public void SwitchState(PlayerStateBase state)
    {
        currentState_ = state;
        currentState_.Enter(this);
    }

    public bool IsInputMove(out Vector2 vector)
    {
        vector = inputActions_.Player.Movement.ReadValue<Vector2>();
        return vector != Vector2.zero;
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