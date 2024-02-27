using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int lastHp_;
    private bool isDeadEventTriggered_ = false;

    public static event Action<int> OnHpChanged;

    public static event Action OnDead;

    private void Awake()
    {
        lastHp_ = PlayerStatus.Instance.Hp;
    }

    private void Update()
    {
        CheckIsHpChanged(PlayerStatus.Instance.Hp);
        CheckIsDead();
    }

    private void CheckIsDead()
    {
        if (isDeadEventTriggered_)
        {
            return;
        }
    }

    private void CheckIsHpChanged(int hp)
    {
        if (lastHp_ != hp)
        {
            lastHp_ = hp;
            OnHpChanged?.Invoke(hp);
        }
    }
}