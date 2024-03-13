using UnityEngine;

public interface IStatus
{
    #region Move

    float MoveSpeed { get; set; }

    #endregion Move

    #region Jump

    float JumpForce { get; set; }
    float JumpBufferTime { get; set; }
    float JumpBufferTimer { get; set; }

    #endregion Jump
}