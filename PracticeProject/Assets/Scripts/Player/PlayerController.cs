using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : CharacterControllerBase
{
    public static event Action OnDestroy;

    private ContactFilter2D attackFilter_;
    private BoxCollider2D attackArea_;

    private new void Awake()
    {
        base.Awake();
        attackFilter_.SetLayerMask(LayerMask.GetMask("Enemy"));
        attackArea_ = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    public void Move(float inputDirection)
    {
        var velocity = rigidbody_.velocity;
        velocity.x = PlayerStatus.Instance.MoveSpeed * inputDirection;
        rigidbody_.velocity = velocity;
        PlayerStatus.Instance.IsFacingRight = inputDirection > 0f;
    }

    public void Jump()
    {
        Knock(new Vector2(0, 1), PlayerStatus.Instance.JumpForce);
    }

    public void Attack()
    {
        var contacts = new Collider2D[5];
        var result = attackArea_.OverlapCollider(attackFilter_, contacts);
        if (result > 0)
        {
            var damage = PlayerStatus.Instance.AttackDamage;
            foreach (var contact in contacts)
            {
                var enemy = contact?.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.Damage(damage);
                    enemy.Knock(PlayerStatus.Instance.IsFacingRight ? Vector2.right : Vector2.left, damage);
                }
            }
        }
    }

    public void Damage(int damage)
    {
        PlayerStatus.Instance.Hp -= damage;
    }

    public void Destroy()
    {
        OnDestroy?.Invoke();
        gameObject.SetActive(false);
    }
}