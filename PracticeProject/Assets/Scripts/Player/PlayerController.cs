using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnDestroy;

    private Rigidbody2D rigidbody_;
    private ContactFilter2D attackFilter_;
    private BoxCollider2D attackArea_;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
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

    public void Stop()
    {
        var velocity = rigidbody_.velocity;
        velocity.x = 0;
        rigidbody_.velocity = velocity;
    }

    public void Jump()
    {
        AddForce(new Vector2(0, 1), PlayerStatus.Instance.JumpForce);
    }

    public void AddForce(Vector2 vector, float force)
    {
        vector.Normalize();
        vector *= force;
        rigidbody_.AddForce(vector, ForceMode2D.Impulse);
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
                    enemy.AddForce(PlayerStatus.Instance.IsFacingRight ? Vector2.right : Vector2.left, damage);
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