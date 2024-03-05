using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverMenu : Singleton<GameOverMenu>
{
    [SerializeField] private GameObject gameOverUi_;
    [SerializeField] private EventSystem eventSystem_;
    [SerializeField] private GameObject selectOnShow_;

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
        gameOverUi_?.SetActive(true);
        eventSystem_?.SetSelectedGameObject(selectOnShow_);
    }
}