using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaremaFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = new Vector3(0f, 0f, -10f);
    [SerializeField] private Vector3 _velocity = Vector3.one;
    [SerializeField] private float _smoothTime = 0.01f;

    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        var targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}