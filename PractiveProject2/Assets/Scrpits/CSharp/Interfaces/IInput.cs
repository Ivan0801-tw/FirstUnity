using UnityEngine;

public enum AttackDriection
{
    Up,
    Front,
    Down,
}

public interface IInput
{
    public Vector2 GetMovement();

    public bool GetJump();

    public AttackDriection GetAttackDirection();

    public bool GetAttack();
}