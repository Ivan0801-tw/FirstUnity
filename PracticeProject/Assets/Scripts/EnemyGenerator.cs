using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab_;

    // Start is called before the first frame update
    private void Start()
    {
        Instantiate(prefab_, transform.localPosition, Quaternion.identity);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}