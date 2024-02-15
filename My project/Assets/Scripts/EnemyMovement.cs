using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Unity Inspector
    [SerializeField] Rigidbody2D rigidbody_;
    [SerializeField] float speed_;
    [SerializeField] PlayerManager playerManager_;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var playerPosition = playerManager_.Position;
        var currentPosition = (Vector2)transform.position;
        var direction = playerPosition - currentPosition;
        direction.Normalize();
        var targetPosition = currentPosition + direction;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();
    }
}
