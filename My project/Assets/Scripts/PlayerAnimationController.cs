using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator_;
    [SerializeField] private SpriteRenderer spriteRenderer_;
    [SerializeField] private string walkState_;
    [SerializeField] private string idleState_;
    [SerializeField] private string attackState_;

    public void Move(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        if (direction.Equals(Vector2.zero))
        {
            animator_.Play(idleState_);
        }
        else
        {
            animator_.Play(walkState_);
        }

        if (direction.x > 0)
        {
            spriteRenderer_.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer_.flipX = true;
        }
    }

    public void Attack()
    {
        animator_.Play(attackState_);
    }
}