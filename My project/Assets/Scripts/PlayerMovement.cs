using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private float speed_;

    //Fields

    private Vector2 inputDirection_;
    private Vector2 lastDireciton_;

    public Vector2 LastDirection
    {
        get
        {
            return lastDireciton_;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputDirection_ = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var currentPosition = (Vector2)transform.position;
        var targetPosition = currentPosition + inputDirection_;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();
        lastDireciton_ = inputDirection_;
    }

    private void LateUpdate()
    {
    }
}