using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Unity Inspector
    [SerializeField] Rigidbody2D rigidbody_;
    [SerializeField] float speed_;

    //Fields
    Vector2 inputDirection_;
    public void Move(InputAction.CallbackContext context)
    {
        inputDirection_ = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = (Vector2)transform.position;
        var targetPosition = currentPosition + inputDirection_;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();
    }

    private void LateUpdate()
    {
    }
}
