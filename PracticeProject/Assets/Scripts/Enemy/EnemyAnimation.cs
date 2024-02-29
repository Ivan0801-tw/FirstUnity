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

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator_;

    private static EnemyAnimation instance_;

    public static EnemyAnimation Instance
    {
        get
        {
            return instance_;
        }
    }

    public bool IsPlaying(EnemyAnimateState animate)
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
        EnemyIdleState.OnEnter += Idle;
        EnemyMoveState.OnEnter += Walk;
        EnemyAttackState.OnEnter += Attack;
        EnemyDieState.OnEnter += Die;
    }

    private void OnDisable()
    {
        EnemyIdleState.OnEnter -= Idle;
        EnemyMoveState.OnEnter -= Walk;
        EnemyAttackState.OnEnter -= Attack;
        EnemyDieState.OnEnter -= Die;
    }

    private void Walk()
    {
        animator_.SetBool(EnemyAnimateState.Walk.ToString(), true);
    }

    private void Idle()
    {
        animator_.SetBool(EnemyAnimateState.Walk.ToString(), false);
        animator_.ResetTrigger(EnemyAnimateState.Attack.ToString());
    }

    private void Attack()
    {
        animator_.SetTrigger(EnemyAnimateState.Attack.ToString());
    }

    private void Die()
    {
        animator_.SetTrigger(EnemyAnimateState.Die.ToString());
    }
}