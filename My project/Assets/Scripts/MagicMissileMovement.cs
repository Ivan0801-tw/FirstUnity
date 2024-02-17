using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MagicMissileMovement : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private float speed_;

    private Vector2 direction_;

    private GameObject LocateEnemy()
    {
        var results = new Collider2D[5];
        Physics2D.OverlapCircleNonAlloc(transform.position, 10, results);
        foreach (var result in results)
        {
            if (result != null && result.CompareTag("Enemy"))
            {
                return result.gameObject;
            }
        }

        //TODO try catch
        return null;
    }

    private Vector2 MoveDircetion(Transform target)
    {
        var direction = new Vector2(1, 0);

        if (target != null)
        {
            direction = target.position - transform.position;
            direction.Normalize();
        }

        return direction;
    }

    private void Awake()
    {
        var enemy = LocateEnemy();
        direction_ = MoveDircetion(enemy?.transform);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction_);
    }

    private void Update()
    {
        var targetPosition = (Vector2)transform.position + direction_;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();
    }
}