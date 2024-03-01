using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyPool pool_;
    [SerializeField] private float maxRange_;
    [SerializeField] private float minRange_;

    [SerializeField] private float interval_ = 1.5f;
    private float timePassed_;

    private void Start()
    {
        GenerateNext();
    }

    private void Update()
    {
        if (timePassed_ < interval_)
        {
            timePassed_ += Time.deltaTime;
            return;
        }
        else
        {
            timePassed_ = 0;
            GenerateNext();
        }
    }

    private void GenerateNext()
    {
        var position = transform.position;
        position.x = Random.Range(minRange_, maxRange_);
        pool_.GetNext(position);
    }
}