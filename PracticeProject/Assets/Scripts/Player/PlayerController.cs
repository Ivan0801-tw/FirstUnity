using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody_;
    private ContactFilter2D attackFilter_;

    private void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        attackFilter_.SetLayerMask(LayerMask.GetMask("Enemy"));
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
        rigidbody_.AddForce(new Vector2(vector.x * force, vector.y * force), ForceMode2D.Impulse);
    }

    public void Attack()
    {
        var collider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        var contacts = new Collider2D[5];
        var result = collider.OverlapCollider(attackFilter_, contacts);
        if (result > 0)
        {
            var damage = PlayerStatus.Instance.AttackDamage;
            foreach (var contact in contacts)
            {
                contact?.GetComponent<EnemyController>()?.Damage(damage);
            }
        }
    }

    public void Damage(int damage)
    {
        PlayerStatus.Instance.Hp -= damage;
        AddForce(PlayerStatus.Instance.IsFacingRight ? Vector2.left : Vector2.right, damage);
    }
}