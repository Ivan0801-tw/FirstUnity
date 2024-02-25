using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Player player_;

    private int lastHp_;

    public static event Action<int> OnHpChanged;

    private void Awake()
    {
        lastHp_ = player_.Hp;
    }

    private void Update()
    {
        CheckIsHpChanged(player_.Hp);
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