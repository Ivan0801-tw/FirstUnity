using UnityEngine;

public interface IStatus
{
    //Move
    float MoveSpeed { get; set; }

    //Jump
    float JumpForce { get; set; }

    float JumpBufferTime { get; set; }
    float JumpBufferTimer { get; set; }
}