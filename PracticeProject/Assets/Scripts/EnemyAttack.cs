using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float coolDownTime_;
    private bool isAttacking_ = false;
    private bool isCoolDown_ = false;
    private bool isPlayerInRange_ = false;

    public bool IsAttacking
    {
        get
        {
            return isAttacking_;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isPlayerInRange_)
        {
            TryAttackPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange_ = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange_ = false;
        }
    }

    private void TryAttackPlayer()
    {
        if (isCoolDown_)
        {
            return;
        }
        isAttacking_ = true;
        GetComponentInParent<Animator>().Play(EnemyAnimation.Attack.ToString());

        isCoolDown_ = true;
        StartCoroutine(refreshCoolDown());
    }

    private IEnumerator refreshCoolDown()
    {
        yield return new WaitForSeconds(coolDownTime_);
        isCoolDown_ = false;
    }

    internal void StopAttack()
    {
        isAttacking_ = false;
    }
}