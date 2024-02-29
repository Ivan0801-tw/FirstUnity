using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private EnemyStateBase currentState_;
    private bool isDead_ = false;

    public readonly EnemyIdleState idle_ = new EnemyIdleState();
    public readonly EnemyMoveState move_ = new EnemyMoveState();
    public readonly EnemyAttackState attack_ = new EnemyAttackState();
    public readonly EnemyDieState die_ = new EnemyDieState();

    private void Start()
    {
        SwitchState(idle_);
    }

    private void Update()
    {
        if (!isDead_ && EnemyStatus.Instance.Hp <= 0)
        {
            isDead_ = true;
            SwitchState(die_);
        }
        currentState_.Update(this);
    }

    public void SwitchState(EnemyStateBase state)
    {
        currentState_ = state;
        currentState_.Enter(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState_.OnCollisionEnter2D(this, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        currentState_.OnCollisionExit2D(this, collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentState_.OnTriggerEnter2D(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentState_.OnTriggerExit2D(this, collision);
    }
}