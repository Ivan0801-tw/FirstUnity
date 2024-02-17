using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource_;
    [SerializeField] private AudioClip gameOverClip_;
    [SerializeField] private AudioClip magicMissileLaunchClip_;
    [SerializeField] private AudioClip takeDamageClip_;

    public void PlayGameOver()
    {
        audioSource_.PlayOneShot(gameOverClip_);
    }

    public void PlayMissileLaunch()
    {
        audioSource_.PlayOneShot(magicMissileLaunchClip_);
    }

    public void PlayTakeDamage()
    {
        audioSource_.PlayOneShot(takeDamageClip_);
    }
}