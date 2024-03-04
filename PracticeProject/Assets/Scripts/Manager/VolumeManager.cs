using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeManager : Singleton<VolumeManager>
{
    private const string key_ = "MusicVolume";
    [SerializeField] private Slider volumeSlider_;

    private new void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey(key_))
        {
            Safe(1.0f);
        }
        Load();
    }

    public void ChangeVolume()
    {
        float value = volumeSlider_.value;
        AudioListener.volume = value;
        Safe(value);
    }

    private void Load()
    {
        volumeSlider_.value = PlayerPrefs.GetFloat(key_);
    }

    private void Safe(float value)
    {
        PlayerPrefs.SetFloat(key_, value);
    }
}