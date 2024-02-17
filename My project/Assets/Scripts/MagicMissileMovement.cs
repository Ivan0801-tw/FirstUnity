using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MagicMissileMovement : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private float speed_;

    private Vector2 targetDirection_;

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

    private Vector2 MoveDircetion(Transform enemtTransform, Vector2 playerDirection)
    {
        var direction = playerDirection;

        if (enemtTransform != null)
        {
            direction = enemtTransform.position - transform.position;
            direction.Normalize();
        }

        return direction;
    }

    private void Awake()
    {
        var enemy = LocateEnemy();
        targetDirection_ = MoveDircetion(enemy?.transform, PlayerManager.Direction);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection_);
    }

    private void Update()
    {
        var targetPosition = (Vector2)transform.position + targetDirection_;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();
    }
}