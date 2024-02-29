using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody_;
    private ContactFilter2D attackFilter_;

    private static EnemyController instance_;

    public static EnemyController Instance
    {
        get
        {
            return instance_;
        }
    }

    private void Awake()
    {
        instance_ = this;
        attackFilter_.SetLayerMask(LayerMask.GetMask("Player"));
    }

    public void Move(float inputDirection)
    {
        var velocity = rigidbody_.velocity;
        velocity.x = EnemyStatus.Instance.MoveSpeed * inputDirection;
        rigidbody_.velocity = velocity;
        EnemyStatus.Instance.IsFacingRight = inputDirection > 0f;
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
        var collider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        var result = collider.OverlapCollider(attackFilter_, contacts);
        return result > 0;
    }

    public void AttackPlayer()
    {
        Collider2D[] contacts;
        if (IsPlayerInRange(out contacts))
        {
            var damage = EnemyStatus.Instance.AttackDamage;
            foreach (var contact in contacts)
            {
                contact?.GetComponent<PlayerController>()?.Damage(damage);
            }
        }
    }

    public void Damage(int damage)
    {
        EnemyStatus.Instance.Hp -= damage;
        AddForce(EnemyStatus.Instance.IsFacingRight ? Vector2.left : Vector2.right, damage);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}