using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private void Move()
    {
        float movement = speed_ * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (isFacingRight_) transform.DOScaleX(-1f, 0);
            isFacingRight_ = false;
            transform.position += new Vector3(-movement, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!isFacingRight_) transform.DOScaleX(1f, 0);
            isFacingRight_ = true;
            transform.position += new Vector3(movement, 0, 0);
        }
    }

    private void Jump()
    {
        if (!canJump_) return;
        if (!isTouchGround_) return;
        if (Input.GetKey(KeyCode.X))
        {
            rigidbody_.AddForce(new Vector2(0f, 1f * jumpForce_), ForceMode2D.Impulse);
            canJump_ = false;
            isTouchGround_ = false;
            StartCoroutine(JumpDelay());
        }
    }

    private IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.2f);
        canJump_ = true;
    }
}