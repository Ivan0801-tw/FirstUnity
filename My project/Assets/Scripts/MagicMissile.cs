using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;
using UnityEngine.Events;

public class MagicMissile : MonoBehaviour
{
    [SerializeField] private MissileCreator creator_;
    [SerializeField] private UnityEvent missileLaunce_;

    private void LaunchMissile()
    {
        creator_.CreateMissile();
        missileLaunce_.Invoke();
    }

    private void Awake()
    {
        TimersManager.SetLoopableTimer(this, 1, LaunchMissile);
    }
}