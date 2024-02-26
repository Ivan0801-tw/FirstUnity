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
        lastHp_ = Player.Instance.Hp;
    }

    private void Update()
    {
        CheckIsHpChanged(Player.Instance.Hp);
        CheckIsDead();
    }

    private void CheckIsDead()
    {
        if (isDeadEventTriggered_)
        {
            return;
        }
        if (Player.Instance.IsDead)
        {
            OnDead?.Invoke();
            isDeadEventTriggered_ = true;
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