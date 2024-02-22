using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attack_;

    [Header("îªù–")]
    private ContactFilter2D enemyFilter;
    private bool isAttacking_ = false;

    // Start is called before the first frame update
    private void Start()
    {
        attack_ = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (isAttacking_) return;
        if (Input.GetKey(KeyCode.Z))
        {
            isAttacking_ = true;
            attack_.SetActive(true);
            StartCoroutine(HideAttackFX());
        }
    }

    private IEnumerator HideAttackFX()
    {
        yield return new WaitForSeconds(1f);
        isAttacking_ = false;
        attack_.SetActive(false);
    }
}