using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private GameObject missilePrefab_;
    [SerializeField] private PlayerManager playerManager_;

    public void CreateMissile()
    {
        Instantiate(missilePrefab_, playerManager_.Position, Quaternion.identity);
    }
}