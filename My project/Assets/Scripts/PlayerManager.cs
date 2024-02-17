using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Transform playerTransform_;
    [SerializeField] private Health playerHealth_;

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

    private void Awake()
    {
        instance_ = this;
    }
}