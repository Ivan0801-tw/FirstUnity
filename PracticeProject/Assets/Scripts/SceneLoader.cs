using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

internal enum Scenes
{
    MainMenu = 0,
    Game = 1,
}

public class SceneLoader : Singleton<SceneLoader>
{
    [SerializeField] private Animator animator_;
    [SerializeField] private AudioSource audioSource_;
    private float transitionTime_ = 1.0f;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(StartLoad(sceneIndex));
    }

    private IEnumerator StartLoad(int sceneIndex)
    {
        animator_.SetTrigger("Start");
        audioSource_?.DOFade(0, 1);
        yield return new WaitForSeconds(transitionTime_);
        SceneManager.LoadScene(sceneIndex);
    }
}