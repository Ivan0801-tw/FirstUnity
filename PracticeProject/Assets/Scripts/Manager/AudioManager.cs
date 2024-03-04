using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource_;

    private void Awake()
    {
        audioSource_?.DOFade(1, 1);
    }
}