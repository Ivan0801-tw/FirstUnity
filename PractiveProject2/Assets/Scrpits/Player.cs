using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputAction _input;

    private void Awake()
    {
        _input = new PlayerInputAction();
        _input.Player.Enable();
        _input.Player.Attack.performed += Attack_performed;
        _input.Player.Jump.performed += Jump_performed;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = _input.Player.Movement.ReadValue<Vector2>();
        if (!inputVector.Equals(Vector2.zero))
        {
            Debug.Log(inputVector);
            transform.Translate(inputVector);
        }
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Attacke Performed");
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump Performed");
    }
}