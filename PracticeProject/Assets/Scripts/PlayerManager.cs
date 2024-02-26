using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int lastHp_;

    public static event Action<int> OnHpChanged;

    private void Awake()
    {
        lastHp_ = Player.Instance.Hp;
    }

    private void Update()
    {
        CheckIsHpChanged(Player.Instance.Hp);
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