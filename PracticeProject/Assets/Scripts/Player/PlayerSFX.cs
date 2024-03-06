using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : Singleton<PlayerSFX>
{
    [SerializeField] private AudioSource audioSource_;
    [SerializeField] private AudioClip attackAudio_;
    [SerializeField] private AudioClip jumpAudio_;
    [SerializeField] private AudioClip walkAudio_;
    [SerializeField] private AudioClip dieAudio_;

    public void StopPlaying()
    {
        audioSource_.Stop();
    }

    public void PlayJump()
    {
        Play(false, ref jumpAudio_);
    }

    public void PlayWalk()
    {
        Play(true, ref walkAudio_);
    }

    public void PlayDie()
    {
        Play(false, ref dieAudio_);
    }

    public void PlayAttack()
    {
        Play(false, ref attackAudio_);
    }

    private void Play(bool isLoop, ref AudioClip clip)
    {
        audioSource_.loop = isLoop;
        audioSource_.clip = clip;
        audioSource_.Play();
    }
}