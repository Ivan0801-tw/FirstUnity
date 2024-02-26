using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOver;

    public static event Action OnRestart;

    private void OnEnable()
    {
        PlayerManager.OnDead += GameOver;
    }

    private void OnDisable()
    {
        PlayerManager.OnDead -= GameOver;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        OnRestart?.Invoke();
        SceneManager.LoadScene(0);
    }
}