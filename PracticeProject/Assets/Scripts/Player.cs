using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator_;
    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private SpriteRenderer renderer_;
    [SerializeField] private PlayerAttack attack_;
    [SerializeField] private int hp_;
    [SerializeField] private float speed_;
    [SerializeField] private float jumpForce_;
    private bool isDead_ = false;
    private bool isTouchGround_ = false;
    private bool isFacingRight_ = true;
    private bool canJump_ = true;

    private static Player instance_;

    private Player()
    {
    }

    public static Player Instance
    {
        get
        {
            if (instance_ != null)
            {
                // õﬂ„Síêç˚ìISingletonï®åè
                return instance_;
            }
            instance_ = FindObjectOfType<Player>();
            //êqùQõﬂ„Sç›SceneìISingletonï®åè:
            if (instance_ != null)
            {
                return instance_;
            }
            // õâéûënåöSingletonï®åè
            CreateDefault();
            return instance_;
        }
    }

    private static void CreateDefault()
    {
        GameObject player = new GameObject("Singleton");
        instance_ = player.AddComponent<Player>();
    }

    private void Awake()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (isDead_)
        {
            return;
        }
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
        if (attack_.IsAttacking)
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

    public void AttackEnemy()
    {
        attack_.AttackEnemy();
    }

    public Vector3 LocalPosition
    {
        get { return transform.localPosition; }
    }

    public int Hp
    {
        get { return hp_; }
    }

    public bool IsDead
    {
        get { return isDead_; }
    }

    public void Damage(int amount)
    {
        hp_ -= amount;
        if (hp_ <= 0)
        {
            isDead_ = true;
            animator_.Play("Die");
        }
        else
        {
            StartCoroutine(ChangeColor(Color.red));
        }
    }

    private IEnumerator ChangeColor(Color color)
    {
        renderer_.DOColor(color, 0.1f);
        yield return new WaitForSeconds(0.2f);
        renderer_.DOColor(Color.white, 0.1f);
    }
}