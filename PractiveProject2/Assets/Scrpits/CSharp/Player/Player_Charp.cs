using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player_Charp : IStatus, IGround
{
    [Inject(Id = "PlayerGround")] private Transform _groundPoint;

    public float MoveSpeed
    { get => 5f; set { } }

    public float JumpForce
    { get => 7f; set { } }

    public float JumpBufferTime
    { get => 0.25f; set { } }

    public float JumpBufferTimer { get; set; } = 0f;

    public bool IsGrounded
    { get => Physics2D.OverlapCircle(Point, Range, LayerMask); set { } }

    public Vector3 Point
    {
        get => _groundPoint.position; set { }
    }

    public float Range
    {
        get => 0.2f; set { }
    }

    public LayerMask LayerMask
    {
        get => LayerMask.GetMask("Ground"); set { }
    }
}