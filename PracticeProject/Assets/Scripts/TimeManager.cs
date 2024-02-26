using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.OnGameOver += StopTime;
        GameManager.OnRestart += StartTime;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= StopTime;
        GameManager.OnRestart -= StartTime;
    }

    private void StopTime()
    {
        Time.timeScale = 0;
    }

    private void StartTime()
    {
        Time.timeScale = 1;
    }
}