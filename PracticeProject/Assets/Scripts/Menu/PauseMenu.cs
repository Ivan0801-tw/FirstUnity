using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu_;
    [SerializeField] private EventSystem eventSystem_;
    [SerializeField] private GameObject selectOnShow_;

    private void OnEnable()
    {
        PauseManager.OnPaused += Show;
        PauseManager.OnContinued += Hide;
    }

    private void OnDisable()
    {
        PauseManager.OnPaused -= Show;
        PauseManager.OnContinued -= Hide;
    }

    private void Show()
    {
        pauseMenu_?.SetActive(true);
        eventSystem_?.SetSelectedGameObject(selectOnShow_);
    }

    private void Hide()
    {
        pauseMenu_?.SetActive(false);
        eventSystem_?.SetSelectedGameObject(null);
    }
}