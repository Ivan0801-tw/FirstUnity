using DG.Tweening;
using System;
using UnityEditor;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int hp_;
    [SerializeField] private float moveSpeed_;
    [SerializeField] private int attackDamage_;
    [SerializeField] private bool isFacingRight_;
    [SerializeField] private float stopTrackRange_;
    private Transform transform_;

    private void Awake()
    {
        transform_ = GetComponent<Transform>();
    }

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

    public float StopTrackRange
    {
        get => stopTrackRange_;
        set => stopTrackRange_ = value;
    }
}