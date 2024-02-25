using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed_;
    [SerializeField] private int hp_;
    [SerializeField] private float stopTrackRange_;
    private Animator animator_;
    private Rigidbody2D rigidbody_;
    private bool isTouchGround_ = false;
    private bool isFacingRight_ = true;

    // Start is called before the first frame update
    private void Start()
    {
        animator_ = GetComponent<Animator>();
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void TrackPlayer()
    {
        //觸碰地面後才能開始移動
        if (!isTouchGround_)
        {
            return;
        }

        var target = Player.LocalPosition;
        var current = transform.localPosition;
        var deltaX = target.x - current.x;

        if (Math.Abs(deltaX) <= stopTrackRange_)
        {
            rigidbody_.velocity = Vector2.zero;
        }
        else
        {
            var newVelocity = new Vector2(deltaX, 0);

            if (newVelocity.magnitude < speed_)
            {
                newVelocity = newVelocity.normalized * speed_;
            }
            rigidbody_.velocity = newVelocity;
        }

        ChangeMoveAnimation(rigidbody_.velocity.x);
    }

    private void ChangeMoveAnimation(float direction)
    {
        if ((direction < 0 && isFacingRight_) ||
            (direction > 0 && !isFacingRight_))
        {
            //Flip
            isFacingRight_ = !isFacingRight_;
            transform.DOScaleX(isFacingRight_ ? 1 : -1, 0);
        }

        animator_.Play(direction != 0 ? "Walk" : "Idle");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchGround_ = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchGround_ = false;
        }
    }

    public void Damage(int amount)
    {
        hp_ -= amount;
        if (hp_ <= 0)
        {
            Destroy(gameObject);
        }
    }
}