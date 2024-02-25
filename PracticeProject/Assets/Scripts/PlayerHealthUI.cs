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
        healthSlider_.maxValue = Player.Hp;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        healthSlider_.value = Player.Hp;
    }
}