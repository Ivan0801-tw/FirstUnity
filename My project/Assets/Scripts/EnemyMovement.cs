using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Rigidbody2D rigidbody_;
    [SerializeField] private float speed_;
    [SerializeField] private UnityEvent<Vector2> moveDirection;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        //get current position of player
        var playerPosition = PlayerManager.Position;
        //get current position of enemy
        var currentPosition = (Vector2)transform.position;
        //count direction from enemy to player
        var direction = playerPosition - currentPosition;
        direction.Normalize();

        //count target position to move
        var targetPosition = currentPosition + direction;
        rigidbody_.DOMove(targetPosition, speed_).SetSpeedBased();

        //Invoke Move Event
        moveDirection.Invoke(direction);
    }
}