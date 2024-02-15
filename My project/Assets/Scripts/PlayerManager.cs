using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Transform playerTransform_;

    public Vector2 Position
    {
        get
        {
            return playerTransform_.position;
        }
    }
}