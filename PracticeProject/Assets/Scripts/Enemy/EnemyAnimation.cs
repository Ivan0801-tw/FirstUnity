using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyAnimateState
{
    Idle,
    Walk,
    Attack,
    Die
}

public class EnemyAnimation : Singleton<EnemyAnimation>
{
    private Animator animator_;

    private new void Awake()
    {
        base.Awake();
        animator_ = GetComponent<Animator>();
    }

    public bool IsPlaying(EnemyAnimateState animate)
    {
        return animator_.GetCurrentAnimatorStateInfo(0).IsName(animate.ToString());
    }

    public void PlayWalk()
    {
        animator_.SetBool(EnemyAnimateState.Walk.ToString(), true);
    }

    public void PlayIdle()
    {
        animator_.SetBool(EnemyAnimateState.Walk.ToString(), false);
        animator_.ResetTrigger(EnemyAnimateState.Attack.ToString());
    }

    public void PlayAttack()
    {
        animator_.SetTrigger(EnemyAnimateState.Attack.ToString());
    }

    public void PlayDie()
    {
        animator_.Play(EnemyAnimateState.Die.ToString());
    }
}