using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canAttack_ = true;

    private void DealDamageToPlayer(Collider2D collision)
    {
        if (!canAttack_) return;
        if (collision.CompareTag("Player"))
        {
            var damageable = collision.GetComponent<Damagealbe>();
            damageable.TakeDamage(1);
            canAttack_ = false;
            TimersManager.SetTimer(this, 1, () => canAttack_ = true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamageToPlayer(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DealDamageToPlayer(collision);
    }
}