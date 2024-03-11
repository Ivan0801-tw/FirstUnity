using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaremaFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _smoothTime;

    [SerializeField] private Transform _target;

    private void FixedUpdate()
    {
        var targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}