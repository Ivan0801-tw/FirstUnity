using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static event Action OnGameOver;

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        PlayerController.OnDestroy += GameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnDestroy -= GameOver;
    }

    public void GameOver()
    {
        TimeManager.Instance.ChangeTimeScale(0);
        OnGameOver?.Invoke();
    }

    public void Restart()
    {
        TimeManager.Instance.ChangeTimeScale(1);
        SceneLoader.Instance.LoadScene((int)Scenes.Game);
    }

    public void Quit()
    {
        Application.Quit();
    }
}