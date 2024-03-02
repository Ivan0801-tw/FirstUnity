using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControllerBase : MonoBehaviour
{
    protected Rigidbody2D rigidbody_;

    protected void Awake()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    public virtual void Stop()
    {
        rigidbody_.velocity = Vector2.zero;
    }

    public void Knock(Vector2 vector, float force)
    {
        vector.Normalize();
        vector *= force;
        rigidbody_.AddForce(vector, ForceMode2D.Impulse);
    }
}