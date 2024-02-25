using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator_;
    [SerializeField] private int hp_;
    [SerializeField] private float speed_;
    [SerializeField] private float jumpForce_;
    private Rigidbody2D rigidbody_;
    private bool isTouchGround_ = false;
    private bool isFacingRight_ = true;
    private bool canJump_ = true;
    private static Player instance_;

    public static Player Instance
    {
        get
        {
            if (instance_ != null)
            {
                // õﬂ„Síêç˚ìISingletonï®åè
                return instance_;
            }
            // êqùQõﬂ„Sç›SceneìISingletonï®åè:
            instance_ = FindObjectOfType<Player>();
            if (instance_ != null)
            {
                return instance_;
            }
            // õâéûënåöSingletonï®åè
            // CreateDefault();
            return instance_;
        }
    }

    private void Awake()
    {
        instance_ = this;
    }

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

    private void Move()
    {
        if (gameObject.GetComponent<PlayerAttack>().IsAttacking)
        {
            if (isTouchGround_) rigidbody_.velocity = new Vector2(0, rigidbody_.velocity.y);
            return;
        }

        float inputDirectionX = Input.GetAxis("Horizontal");
        rigidbody_.velocity = new Vector2(speed_ * inputDirectionX, rigidbody_.velocity.y);
        ChangeMoveAnimation(inputDirectionX);
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

    public static Vector3 LocalPosition
    {
        get { return Instance.transform.localPosition; }
    }

    public static int Hp
    {
        get { return Instance.hp_; }
    }

    public static void Damage(int amount)
    {
        Instance.hp_ -= amount;
    }
}