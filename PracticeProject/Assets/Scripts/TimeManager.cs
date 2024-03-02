using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    public void ChangeTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
}