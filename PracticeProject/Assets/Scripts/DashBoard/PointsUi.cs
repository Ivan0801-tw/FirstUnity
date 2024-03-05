using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsUi : MonoBehaviour
{
    private int point_ = 0;
    [SerializeField] private TextMeshProUGUI text_;

    private void OnEnable()
    {
        EnemyController.OnDestroy += AddPoint;
    }

    private void OnDisable()
    {
        EnemyController.OnDestroy -= AddPoint;
    }

    private void AddPoint()
    {
        point_ += 1;
    }

    private void Update()
    {
        text_.text = "Points:" + point_;
    }
}