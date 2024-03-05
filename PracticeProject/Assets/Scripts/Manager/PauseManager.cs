using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] private AudioManager audioManager_;
    private PlayerInputActions inputActions_;
    private bool isPaused_ = false;

    private new void Awake()
    {
        base.Awake();
        inputActions_ = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions_.Pause.Enable();
        inputActions_.Pause.Pause.performed += Pause_performed;
    }

    private void OnDisable()
    {
        inputActions_.Pause.Pause.performed -= Pause_performed;
        inputActions_.Pause.Disable();
    }

    private void Pause_performed(InputAction.CallbackContext context)
    {
        if (!isPaused_)
        {
            isPaused_ = true;
            audioManager_.SetToPaused();
            TimeManager.Instance.ChangeTimeScale(0);
        }
        else
        {
            isPaused_ = false;
            audioManager_.SetToNormal();
            TimeManager.Instance.ChangeTimeScale(1);
        }
    }
}