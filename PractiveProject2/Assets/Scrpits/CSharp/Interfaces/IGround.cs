using UnityEngine;

public interface IGround
{
    bool IsGrounded { get; set; }
    Vector3 Point { get; set; }
    float Range { get; set; }
    LayerMask LayerMask { get; set; }
}