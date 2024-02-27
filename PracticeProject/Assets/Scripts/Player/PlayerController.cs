using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody_;

    private static PlayerController instance_;

    public static PlayerController Instance
    {
        get
        {
            return instance_;
        }
    }

    private void Awake()
    {
        instance_ = this;
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
        Debug.Log("Attack");
    }
}