using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;
using System;

internal enum Arms
{
    Bush,
    Wood,
    Sign,
}

public class ArmHandler : MonoBehaviour
{
    [SerializeField] private GameObject _arm;

    [SerializeField]
    private SerializableDictionaryBase<Arms, GameObject> _armDictionary;

    // Start is called before the first frame update
    private void Start()
    {
        var arm = Instantiate(_armDictionary[Arms.Bush], transform.localPosition, Quaternion.identity);
        arm.transform.SetParent(transform, false);
    }

    public void SwitchArm()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        Array values = Enum.GetValues(typeof(Arms));
        System.Random random = new System.Random();
        Arms randomBar = (Arms)values.GetValue(random.Next(values.Length));

        var arm = Instantiate(_armDictionary[randomBar], transform.localPosition, Quaternion.identity);
        arm.transform.SetParent(transform, false);
    }
}