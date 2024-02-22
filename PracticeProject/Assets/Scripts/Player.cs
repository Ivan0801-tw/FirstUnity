using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed_;
    [SerializeField] private float jumpForce_;
    private Rigidbody2D rigidbody_;
    private bool isTouchGround_ = false;
    private bool isFacingRight_ = true;
    private bool canJump_ = true;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchGround_ = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchGround_ = false;
        }
    }

    private void Move()
    {
        rigidbody_.velocity = new Vector2(speed_ * Input.GetAxis("Horizontal"), rigidbody_.velocity.y);
        if ((Input.GetAxis("Horizontal") < 0 && isFacingRight_) ||
            (Input.GetAxis("Horizontal") > 0 && !isFacingRight_))
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight_ = !isFacingRight_;
        transform.DOScaleX(isFacingRight_ ? 1 : -1, 0);
    }

    private void Jump()
    {
        if (!canJump_) return;
        if (!isTouchGround_) return;
        if (Input.GetKey(KeyCode.X))
        {
            rigidbody_.AddForce(new Vector2(0f, 1f * jumpForce_), ForceMode2D.Impulse);
            canJump_ = false;
            StartCoroutine(JumpDelay());
        }
    }

    private IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.2f);
        canJump_ = true;
    }
}