using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimateState
{
    Idle,
    Walk,
    Jump,
    InAir,
    Attack,
    Die
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator_;

    private static PlayerAnimation instance_;

    public static PlayerAnimation Instance
    {
        get
        {
            return instance_;
        }
    }

    public bool IsPlaying(PlayerAnimateState animate)
    {
        return animator_.GetCurrentAnimatorStateInfo(0).IsName(animate.ToString()) &&
            animator_.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }

    private void Awake()
    {
        instance_ = this;
    }

    private void OnEnable()
    {
        PlayerIdleState.OnEnter += Idle;
        PlayerMoveState.OnEnter += Walk;
        PlayerJumpState.OnEnter += Jump;
        PlayerAttackState.OnEnter += Attack;
        PlayerIdleInAirState.OnEnter += InAir;
        PlayerMoveInAirState.OnEnter += InAir;
    }

    private void OnDisable()
    {
        PlayerIdleState.OnEnter -= Idle;
        PlayerMoveState.OnEnter -= Walk;
        PlayerJumpState.OnEnter -= Jump;
        PlayerAttackState.OnEnter -= Attack;
        PlayerIdleInAirState.OnEnter -= InAir;
        PlayerMoveInAirState.OnEnter -= InAir;
    }

    private void Jump()
    {
        animator_.SetTrigger(PlayerAnimateState.Jump.ToString());
    }

    private void Walk()
    {
        animator_.SetBool(PlayerAnimateState.Walk.ToString(), true);
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), false);
    }

    private void Idle()
    {
        animator_.SetBool(PlayerAnimateState.Walk.ToString(), false);
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), false);
        animator_.ResetTrigger(PlayerAnimateState.Attack.ToString());
        animator_.ResetTrigger(PlayerAnimateState.Jump.ToString());
    }

    private void InAir()
    {
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), true);
    }

    private void Attack()
    {
        animator_.SetTrigger(PlayerAnimateState.Attack.ToString());
    }
}