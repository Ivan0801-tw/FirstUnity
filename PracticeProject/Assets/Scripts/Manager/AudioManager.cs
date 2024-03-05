using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource_;

    private void Awake()
    {
        audioSource_?.DOFade(1, 1);
    }

    public void SetToPaused()
    {
        audioSource_.volume = 0.2f;
    }

    public void SetToNormal()
    {
        audioSource_.volume = 1f;
    }
}