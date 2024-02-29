using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] public GameObject prefab_;
    [SerializeField] public int initailSize_ = 20;

    private Queue<GameObject> pool_ = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < initailSize_; i++)
        {
            var enemy = Instantiate(prefab_);
            enemy.SetActive(false);
            pool_.Enqueue(enemy);
        }
    }

    public void GetNext(Vector3 position)
    {
        if (pool_.Count > 0)
        {
            var enemy = pool_.Dequeue();
            enemy.transform.position = position;
            enemy.SetActive(true);
        }
        else
        {
            var enemy = Instantiate(prefab_);
            enemy.transform.position = position;
        }
    }

    public void Recovery(GameObject enemy)
    {
        pool_.Enqueue(enemy);
        enemy.SetActive(false);
    }
}