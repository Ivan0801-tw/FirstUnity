using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
}