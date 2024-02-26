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
        healthSlider_.maxValue = Player.Instance.Hp;
        healthSlider_.value = Player.Instance.Hp;
    }

    private void OnEnable()
    {
        PlayerManager.OnHpChanged += RefreshHealthBar;
    }

    private void OnDisable()
    {
        PlayerManager.OnHpChanged -= RefreshHealthBar;
    }

    private void RefreshHealthBar(int health)
    {
        healthSlider_.value = health;
    }
}