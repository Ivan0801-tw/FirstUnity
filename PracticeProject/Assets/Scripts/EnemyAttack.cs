using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float coolDownTime_;
    private bool isCoolDown_ = false;
    private bool isPlayerInRange_ = false;

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
        Debug.Log("Attack");
        isCoolDown_ = true;
        StartCoroutine(refreshCoolDown());
    }

    private IEnumerator refreshCoolDown()
    {
        yield return new WaitForSeconds(coolDownTime_);
        isCoolDown_ = false;
    }
}