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

public class PlayerAnimation : Singleton<PlayerAnimation>
{
    private Animator animator_;

    public bool IsPlaying(PlayerAnimateState animate)
    {
        return animator_.GetCurrentAnimatorStateInfo(0).IsName(animate.ToString());
    }

    private new void Awake()
    {
        base.Awake();
        animator_ = GetComponent<Animator>();
    }

    public void PlayJump()
    {
        animator_.SetTrigger(PlayerAnimateState.Jump.ToString());
    }

    public void PlayWalk()
    {
        animator_.SetBool(PlayerAnimateState.Walk.ToString(), true);
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), false);
    }

    public void PlayIdle()
    {
        animator_.SetBool(PlayerAnimateState.Walk.ToString(), false);
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), false);
        animator_.ResetTrigger(PlayerAnimateState.Attack.ToString());
        animator_.ResetTrigger(PlayerAnimateState.Jump.ToString());
    }

    public void PlayInAir()
    {
        animator_.SetBool(PlayerAnimateState.InAir.ToString(), true);
    }

    public void PlayAttack()
    {
        animator_.SetTrigger(PlayerAnimateState.Attack.ToString());
    }

    public void PlayDie()
    {
        animator_.SetTrigger(PlayerAnimateState.Die.ToString());
    }
}