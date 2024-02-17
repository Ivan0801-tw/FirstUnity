using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    //Unity Inspector

    [SerializeField] private Slider healthBar_;

    //[SerializeField] private Health health_;
    [SerializeField] private PlayerManager playerManager_;

    // Start is called before the first frame update
    private void Start()
    {
        healthBar_.maxValue = playerManager_.Health;
        healthBar_.value = playerManager_.Health;
    }

    public void UpdateUI()
    {
        UpdatePlayerHealth();
    }

    private void UpdatePlayerHealth()
    {
        healthBar_.value = playerManager_.Health;
    }
}