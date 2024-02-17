using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Damagealbe : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Health health_;
    [SerializeField] private SpriteRenderer spriteRenderer_;

    public void TakeDamage(int damage)
    {
        health_.Decrease(damage);
        spriteRenderer_.DOColor(Color.red, 0.2f).SetLoops(2, LoopType.Yoyo).ChangeStartValue(Color.white);
    }
}