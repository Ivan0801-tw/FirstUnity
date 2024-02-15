using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Transform playerTransform_;
    [SerializeField] private Health playerHealth_;

    public Vector2 Position
    {
        get
        {
            return playerTransform_.position;
        }
    }

    public int Health
    {
        get
        {
            return playerHealth_.Value;
        }
    }
}