using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;

public class MagicMissile : MonoBehaviour
{
    [SerializeField] private MissileCreator creator_;

    private void LaunchMissile()
    {
        creator_.CreateMissile();
    }

    private void Awake()
    {
        TimersManager.SetLoopableTimer(this, 1, LaunchMissile);
    }
}