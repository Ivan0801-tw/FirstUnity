using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator_;
    private GameObject attack_;

    [Header("îªù–")]
    private ContactFilter2D enemyFilter;
    private bool isAttacking_ = false;

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
            animator_.Play("Attack");
            StartCoroutine(HideAttackFX());
        }
    }

    private IEnumerator HideAttackFX()
    {
        yield return new WaitForSeconds(1f);
        isAttacking_ = false;
        attack_.SetActive(false);
        animator_.StopPlayback();
    }
}