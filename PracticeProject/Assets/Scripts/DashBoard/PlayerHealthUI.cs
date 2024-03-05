using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private Slider healthSlider_;

    private void Awake()
    {
        healthSlider_ = GetComponent<Slider>();
        healthSlider_.maxValue = PlayerStatus.Instance.Hp;
        healthSlider_.value = PlayerStatus.Instance.Hp;
    }

    private void OnEnable()
    {
        PlayerStatus.Instance.OnHpChanged += RefreshHealthBar;
    }

    private void OnDisable()
    {
        PlayerStatus.Instance.OnHpChanged -= RefreshHealthBar;
    }

    private void RefreshHealthBar(int health)
    {
        healthSlider_.value = health;
    }
}