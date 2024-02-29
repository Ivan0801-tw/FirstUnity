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

    public float StopTrackRange
    {
        get => stopTrackRange_;
        set => stopTrackRange_ = value;
    }

    private static EnemyStatus instance_;

    public static EnemyStatus Instance
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