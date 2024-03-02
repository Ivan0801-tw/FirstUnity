using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidbody_;
    private ContactFilter2D attackFilter_;
    private BoxCollider2D attatckArea_;
    private EnemyStatus status_;

    public static event Action OnDestroy;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
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

    public void Stop()
    {
        var velocity = rigidbody_.velocity;
        velocity.x = 0;
        rigidbody_.velocity = velocity;
    }

    public void AddForce(Vector2 vector, float force)
    {
        vector.Normalize();
        rigidbody_.AddForce(new Vector2(vector.x * force, vector.y * force), ForceMode2D.Impulse);
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
                contact?.GetComponent<PlayerController>()?.Damage(damage);
            }
        }
    }

    public void Damage(int damage)
    {
        status_.Hp -= damage;
        AddForce(status_.IsFacingRight ? Vector2.left : Vector2.right, damage);
    }

    public void Destroy()
    {
        OnDestroy?.Invoke();
        Destroy(gameObject);
    }
}