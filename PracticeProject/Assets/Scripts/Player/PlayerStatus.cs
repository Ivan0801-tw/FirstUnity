using DG.Tweening;
using System;
using UnityEditor;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private int hp_;
    [SerializeField] private float moveSpeed_;
    [SerializeField] private float jumpForce_;
    [SerializeField] private float attackDamage_;
    [SerializeField] private bool isFacingRight_;

    public int Hp
    {
        get => hp_;
        set => hp_ = value;
    }

    public float MoveSpeed
    {
        get => moveSpeed_;
        set => moveSpeed_ = value;
    }

    public float JumpForce
    {
        get => jumpForce_;
        set => jumpForce_ = value;
    }

    public float AttackDamage
    {
        get => attackDamage_;
        set => attackDamage_ = value;
    }

    public Vector3 LocalPosition
    {
        get => transform.localPosition;
    }

    public bool IsFacingRight
    {
        get => isFacingRight_;
        set
        {
            if (isFacingRight_ != value)
            {
                transform.DOScaleX(value ? 1 : -1, 0);
            }
            isFacingRight_ = value;
        }
    }

    private static PlayerStatus instance_;

    public static PlayerStatus Instance
    {
        get
        {
            return instance_;
        }
    }

    private void Awake()
    {
        instance_ = this;
    }
}