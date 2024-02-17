using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private string targetTag_;
    [SerializeField] private UnityEvent attack_;

    private bool canAttack_ = true;

    private void DealDamage(Collider2D collision)
    {
        if (!canAttack_) return;
        if (collision.CompareTag(targetTag_))
        {
            var damageable = collision.GetComponent<Damagealbe>();
            damageable.TakeDamage(1);
            canAttack_ = false;
            TimersManager.SetTimer(this, 1, () => canAttack_ = true);
            attack_.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DealDamage(collision);
    }
}