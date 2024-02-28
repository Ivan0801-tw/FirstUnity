using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int hp_;

    private int Hp
    {
        get => hp_;
        set
        {
            if (hp_ != value)
            {
                OnHpChanged?.Invoke(value);
            }
            if (value <= 0)
            {
                OnDead?.Invoke();
            }
            hp_ = value;
        }
    }

    public static event Action<int> OnHpChanged;

    public static event Action OnDead;

    private void Update()
    {
        PollingHp();
    }

    private void PollingHp()
    {
        Hp = PlayerStatus.Instance.Hp;
    }
}