using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : CharacterControllerBase
{
    public static event Action OnDestroy;

    private ContactFilter2D attackFilter_;
    private BoxCollider2D attatckArea_;
    private EnemyStatus status_;

    private new void Awake()
    {
        base.Awake();
        attackFilter_.SetLayerMask(LayerMask.GetMask("Player"));
        status_ = GetComponent<EnemyStatus>();
        attatckArea_ = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    public void Move(float inputDirection)
    {
        var velocity = rigidbody_.velocity;
        velocity.x = status_.MoveSpeed * inputDirection;
        rigidbody_.velocity = velocity;
        status_.IsFacingRight = inputDirection > 0f;
    }

    public bool IsPlayerInRange(out Collider2D[] contacts)
    {
        contacts = new Collider2D[1];
        var result = attatckArea_.OverlapCollider(attackFilter_, contacts);
        return result > 0;
    }

    public void AttackPlayer()
    {
        Collider2D[] contacts;
        if (IsPlayerInRange(out contacts))
        {
            var damage = status_.AttackDamage;
            foreach (var contact in contacts)
            {
                var player = contact?.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.Damage(damage);
                    player.Knock(status_.IsFacingRight ? Vector2.right : Vector2.left, damage);
                }
            }
        }
    }

    public void Damage(int damage)
    {
        status_.Hp -= damage;
    }

    public void Destroy()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }

    public override void Stop()
    {
        rigidbody_.velocity = new Vector2(0, rigidbody_.velocity.y);
    }
}