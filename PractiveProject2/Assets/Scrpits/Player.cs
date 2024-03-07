using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputAction input_;

    private void Awake()
    {
        input_ = new PlayerInputAction();
        input_.Enable();
        input_.Player.Beat.performed += BeatDropped;
    }

    private void BeatDropped(InputAction.CallbackContext context)
    {
        Debug.Log("Beat Dropped");
    }
}