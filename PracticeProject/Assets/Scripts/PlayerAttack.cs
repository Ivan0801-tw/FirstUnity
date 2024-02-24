using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator animator_;
    private GameObject attack_;

    [Header("îªù–")]
    private ContactFilter2D enemyFilter_;
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
        enemyFilter_.SetLayerMask(LayerMask.GetMask("Enemy"));
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
            animator_.Play("Attack");
            StartCoroutine(HideAttackFX());
        }
    }

    private IEnumerator HideAttackFX()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking_ = false;
        animator_.StopPlayback();
    }

    private void AttackEnemy()
    {
        Debug.Log("AttackEnemy");
        Collider2D[] enemyColliderList = new Collider2D[10];
        var enemyCount = attack_.GetComponent<BoxCollider2D>().OverlapCollider(enemyFilter_, enemyColliderList);
        if (enemyCount > 0)
        {
            foreach (var enemyCollider in enemyColliderList)
            {
                enemyCollider?.GetComponent<Enemy>()?.Damage(1);
            }
        }
    }
}