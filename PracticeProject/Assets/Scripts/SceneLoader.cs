using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal enum Scenes
{
    MainMenu = 0,
    Game = 1,
}

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private Animator animator_;
    private float transitionTime_ = 1.0f;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(StartLoad(sceneIndex));
    }

    private IEnumerator StartLoad(int sceneIndex)
    {
        animator_.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime_);
        SceneManager.LoadScene(sceneIndex);
    }
}