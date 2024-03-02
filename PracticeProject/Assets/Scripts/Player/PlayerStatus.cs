using DG.Tweening;
using System;
using UnityEditor;
using UnityEngine;

public class PlayerStatus : Singleton<PlayerStatus>
{
    public event Action<int> OnHpChanged;

    [SerializeField] private int hp_;
    [SerializeField] private float moveSpeed_;
    [SerializeField] private float jumpForce_;
    [SerializeField] private int attackDamage_;
    [SerializeField] private bool isFacingRight_;
    private Transform transform_;

    private new void Awake()
    {
        base.Awake();
        transform_ = GetComponent<Transform>();
    }

    public int Hp
    {
        get => hp_;
        set
        {
            if (hp_ != value)
            {
                OnHpChanged?.Invoke(value);
            }
            hp_ = value;
        }
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

    public int AttackDamage
    {
        get => attackDamage_;
        set => attackDamage_ = value;
    }

    public Vector3 LocalPosition
    {
        get => transform_.localPosition;
    }

    public bool IsFacingRight
    {
        get => isFacingRight_;
        set
        {
            if (isFacingRight_ != value)
            {
                transform_.DOScaleX(value ? 1 : -1, 0);
            }
            isFacingRight_ = value;
        }
    }
}