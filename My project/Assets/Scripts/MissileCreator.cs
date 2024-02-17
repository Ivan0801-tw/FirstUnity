using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private GameObject missilePrefab_;

    public void CreateMissile()
    {
        Instantiate(missilePrefab_, PlayerManager.Position, Quaternion.identity);
    }
}