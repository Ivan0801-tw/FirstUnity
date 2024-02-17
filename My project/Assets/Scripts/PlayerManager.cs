using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Transform playerTransform_;
    [SerializeField] private Health playerHealth_;
    [SerializeField] private PlayerMovement playerMovement_;

    private static PlayerManager instance_;

    public static Vector2 Position
    {
        get
        {
            return instance_.playerTransform_.position;
        }
    }

    public int Health
    {
        get
        {
            return playerHealth_.Value;
        }
    }

    public static Vector2 Direction
    {
        get
        {
            return instance_.playerMovement_.LastDirection;
        }
    }

    private void Awake()
    {
        instance_ = this;
    }
}