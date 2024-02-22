﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed_;
    [SerializeField] private float stopTrackRange_;
    [SerializeField] private GameObject player_;
    private Rigidbody2D rigidbody_;
    private bool isTouchGround_ = false;

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        TrackPlayer();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void TrackPlayer()
    {
        //觸碰地面後才能開始移動
        if (!isTouchGround_)
        {
            return;
        }

        var target = player_.transform.localPosition;
        var current = transform.localPosition;
        var delta = target - current;

        if (delta.magnitude < stopTrackRange_)
        {
            rigidbody_.velocity = Vector2.zero;
            return;
        }

        var newVelocity = new Vector2(delta.x, 0);

        if (newVelocity.magnitude < speed_)
        {
            newVelocity = newVelocity.normalized * speed_;
        }
        rigidbody_.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchGround_ = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchGround_ = false;
        }
    }
}