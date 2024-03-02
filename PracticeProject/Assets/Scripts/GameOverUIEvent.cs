using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIEvent : Singleton<GameOverUIEvent>
{
    [SerializeField] private GameObject gameOverUi_;

    private void OnEnable()
    {
        GameManager.OnGameOver += Show;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= Show;
    }

    private void Show()
    {
        if (gameOverUi_ != null)
        {
            gameOverUi_.SetActive(true);
        }
    }
}